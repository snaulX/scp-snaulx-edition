using System;
using System.Text;
using UnityEngine;

public class SimplePlayerReceiver : MonoBehaviour {
    public Transform target = null;
    public string asciiString = "";
    public string utf8String = "";
    public int animationIndex = -1;

    private void Start() {
        if ( target == null ) {
            target = transform;
        }
    }

    public void AppendPosition( byte[] data ) {
        // Input should be raw vector3
        if ( data.Length != 12 ) return;
        float[] v = new float[ 3 ];
        Buffer.BlockCopy( data, 0, v, 0, 12 );
        AppendPosition( new Vector3( v[ 0 ], v[ 1 ], v[ 2 ] ) );
    }
    public void AppendPosition( Vector3 p ) => target.position = p;

    public void AppendRotation( byte[] data ) {
        // Input should be raw Quaternion
        if ( data.Length != 16 ) return;
        float[] q = new float[ 4 ];
        Buffer.BlockCopy( data, 0, q, 0, 16 );
        AppendRotation( new Quaternion( q[ 0 ], q[ 1 ], q[ 2 ], q[ 3 ] ) );
    }
    public void AppendRotation( Quaternion r ) => target.rotation = r;

    public void AppendLocalRotation( byte[] data ) {
        // Input should be raw Quaternion
        if ( data.Length != 16 ) return;
        float[] q = new float[ 4 ];
        Buffer.BlockCopy( data, 0, q, 0, 16 );
        AppendLocalRotation( new Quaternion( q[ 0 ], q[ 1 ], q[ 2 ], q[ 3 ] ) );
    }
    public void AppendLocalRotation( Quaternion r ) => target.localRotation = r;

    public void AppendASCII( byte[] data ) {
        // input should be raw encoded ASCII string
        asciiString = Encoding.ASCII.GetString( data );
    }

    public void AppendUTF8( byte[] data ) {
        // input should be raw encoded UTF8 string
        utf8String = Encoding.UTF8.GetString( data );
    }

    public void AppendAnimationIndex( byte[] data ) {
        if ( data.Length != 4 ) return;
        animationIndex = BitConverter.ToInt32( data, 0 );
    }
}
