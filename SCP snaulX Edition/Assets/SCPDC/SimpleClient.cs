using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SimpleClient : MonoBehaviour {
    public string hostname = "localhost";
    public int port = 1215;
    public SimpleParser parser;
    public TcpClient client;
    public Thread readThread;
    public Thread writeThread;
    public bool connected = false;
    public bool error = false;
    public List<byte[]> clientQueue;
    public List<byte[]> sendQueue;

    public bool connect = false;
    public bool disconnect = false;

    private void Start() {
        clientQueue = new List<byte[]>();
    }

    private void Update() {
        if ( connect ) { connect = false; Connect( hostname, port ); }
        if ( disconnect ) { disconnect = false; Disconnect(); }

        if ( clientQueue.Count == 0 ) return;
        
        while ( clientQueue.Count > 0 ) {
            try {
                if ( parser != null ) {
                    parser.Parse( clientQueue[ 0 ] );
                }
            } catch ( Exception e ) {
                Debug.LogError( $"QueueException:\n{e.Message}" );
            } finally {
                clientQueue.RemoveAt( 0 );
            }
        }
    }

    public void Connect( string hostname, int port ) {
        try {
            client = new TcpClient( hostname, port );
            readThread = new Thread( ClientThread );
            readThread.Start();
            writeThread = new Thread( ClientSend );
            writeThread.Start();
            connected = true;
        } catch ( Exception e ) {
            Debug.LogError( e.Message );
        }
    }

    public void Disconnect() {
        try {
            client.Client.Shutdown( SocketShutdown.Both );
        } catch ( Exception e ) {
            Debug.LogError( e.Message );
        } finally {
            try { readThread.Abort(); } finally { }
            try { writeThread.Abort(); } finally { }
            connected = false;
            error = false;
            client.Client.Close();
        }
    }

    public void ClientThread() {
        while( connected ) {
            try {
                if ( client.Available > 0 && !error ) {
                    byte[] buffer = new byte[ 65535 ];
                    int byteCount = client.Client.Receive( buffer );
                    if ( byteCount != 0 && byteCount != -1 ) {
                        byte[] data = new byte[ byteCount ];
                        Buffer.BlockCopy( buffer, 0, data, 0, byteCount );
                        if ( data[ 0 ] == 0xFF && data[ 1 ] == 0xFF && data[ 2 ] == 0xFF && data[ 3 ] == 0xFF ) {
                            continue;
                        } else {
                            clientQueue.Add( data );
                        }
                    }
                } else {
                    Thread.Sleep( 16 );
                }
            } catch( SocketException se ) {
                Debug.LogError( $"SocketException:\n{se.Message}" );
                byte retryCount = 0;
                // Try to connect again
                while ( retryCount < 4 ) {
                    try {
                        client.Client.Send( BitConverter.GetBytes( 0xFFFFFFFF ) );
                        retryCount = 0;
                        error = false;
                        break;
                    } catch ( SocketException ) {
                        Debug.Log( $"Try {retryCount}..." );
                    } catch( Exception ee ) {
                        Debug.Log( $"Internal exception on try:\n{ee.Message}" );
                    }
                    retryCount++;
                    Thread.Sleep( 1000 );
                }
                if ( retryCount == 4 ) {
                    Debug.LogError( "Failed to connect after 3 retries" );
                    connected = false;
                    return;
                }
            } catch ( Exception e ) {
                Debug.LogError( $"InternalException\n{e.Message}" );
            }
        }
    }

    public void ClientSend() {
        while( connected ) {
            try {
                if ( sendQueue.Count > 0 && !error ) {
                    client.Client.Send( sendQueue[ 0 ] );
                    sendQueue.RemoveAt( 0 );
                } else {
                    Thread.Sleep( 16 );
                }
            } catch ( SocketException se ) {
                error = true;
                Debug.LogError( $"SocketException:\n{se.Message}" );
                byte retryCount = 0;
                // Try to connect again
                while ( retryCount < 4 ) {
                    try {
                        client.Client.Send( BitConverter.GetBytes( 0xFFFFFFFF ) );
                        retryCount = 0;
                        error = false;
                        break;
                    } catch ( SocketException ) {
                        retryCount++;
                        Debug.Log( $"Try {retryCount}..." );
                        Thread.Sleep( 1000 );
                    } catch ( Exception ee ) {
                        Debug.Log( $"Internal exception on try:\n{ee.Message}" );
                        Thread.Sleep( 1000 );
                    }
                }
                if ( retryCount == 4 ) {
                    Debug.LogError( "Failed to connect after 3 retries" );
                    connected = false;
                    return;
                }
            } catch ( Exception e ) {
                Debug.LogError( $"InternalException\n{e.Message}" );
            }
        }
    }
}
