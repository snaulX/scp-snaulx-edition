using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class SimpleServer : MonoBehaviour {
    public class ClientHandler {
        public int id;
        public bool error;
        public TcpClient client;
        public Thread thread;

        public ClientHandler( int id, TcpClient client, Thread thread ) {
            this.id = id;
            this.error = false;
            this.client = client;
            this.thread = thread;
        }
    }

    public class ClientData {
        public ClientHandler clientHandler;
        public byte[] data;

        public ClientData( ClientHandler clientHandler, byte[] data ) {
            this.clientHandler = clientHandler;
            this.data = data;
        }
    }

    public int port = 1215;
    public bool started = false;
    public bool start = false;
    public bool stop = false;
    public TcpListener server;
    public Thread serverThread;
    public List<ClientHandler> clients;
    public List<ClientData> dataQueue;
    public void StartServer( int port ) {
        try {
            server = new TcpListener( IPAddress.Any, port );
            server.Start();
            serverThread = new Thread( ServerThread );
            serverThread.Start();
            started = true;
        } catch ( Exception e ) {
            Debug.LogError( $"Failed to create server:\n{e.Message}" );
        }
    }

    public void StopServer() {
        while( clients.Count > 0 ) {
            try {
                clients[ 0 ].client.Client.Shutdown( SocketShutdown.Both );
            } finally {
                try { clients[ 0 ].thread.Abort(); } finally { }
                clients[ 0 ].client.Client.Close();
                clients.RemoveAt( 0 );
            }
        }

        try {
            serverThread.Abort();
        } finally { }

        try { server.Stop(); } finally { }
    }

    public void ServerThread() {
        while( started ) {
            try {
                server.BeginAcceptTcpClient( ( IAsyncResult ar ) => {
                    TcpClient client = server.EndAcceptTcpClient( ar );
                    if ( client != null ) {
                        Thread thread = new Thread( ClientThread );
                        ClientHandler clientHandler = new ClientHandler(
                            new System.Random().Next() % 10000000,
                            client,
                            thread
                        );
                        thread.Start( clientHandler );
                        clients.Add( clientHandler );
                    }
                }, null );
            } catch ( SocketException se ) {
                Debug.LogError( $"SocketException[{se.ErrorCode}]:\n{se.Message}" );
            } catch ( Exception e ) {
                Debug.LogError( $"InternalException:\n{e.Message}" );
            }
        }
    }

    public void ClientThread( object clientObject ) {
        ClientHandler clientHandler = clientObject as ClientHandler;
        TcpClient client = clientHandler.client;
        while( true ) {
            try {
                if ( client.Client.Available > 0 ) {
                    byte[] buffer = new byte[ 65535 ];
                    int byteCount = client.Client.Receive( buffer );
                    if ( byteCount != 0 && byteCount != -1 ) {
                        byte[] data = new byte[ byteCount ];
                        Buffer.BlockCopy( buffer, 0, data, 0, byteCount );
                        if ( data[ 0 ] == 0xFF && data[ 1 ] == 0xFF && data[ 2 ] == 0xFF && data[ 3 ] == 0xFF ) {
                            continue;
                        } else {
                            dataQueue.Add( new ClientData( clientHandler, data ) );
                        }
                    }
                } else {
                    Thread.Sleep( 16 );
                }
            } catch ( SocketException se ) {
                Debug.LogError( $"SocketException:\n{se.Message}" );
                byte retryCount = 0;
                // Try to connect again
                while ( retryCount < 4 ) {
                    try {
                        client.Client.Send( BitConverter.GetBytes( 0xFFFFFFFF ) );
                        retryCount = 0;
                        clientHandler.error = false;
                        break;
                    } catch ( SocketException ) {
                        Debug.Log( $"Try {retryCount}..." );
                    } catch ( Exception ee ) {
                        Debug.Log( $"Internal exception on try:\n{ee.Message}" );
                    }
                    retryCount++;
                    Thread.Sleep( 1000 );
                }
                if ( retryCount == 4 ) {
                    Debug.LogError( "Failed to connect after 3 retries" );
                    try {
                        client.Client.Shutdown( SocketShutdown.Both );
                        clients.Remove( clientHandler );
                    } finally {
                        client.Client.Close();
                    }
                    return;
                }
            } catch ( Exception e ) {
                Debug.LogError( $"InternalException\n{e.Message}" );
            }

            // Do someBADIKOV
        }
    }
}
