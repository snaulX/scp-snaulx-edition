using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleParser : MonoBehaviour {
    [Serializable]
    public class TargetID {
        public int id;
        public SimplePlayerReceiver receiver;
        public TargetID( int id, SimplePlayerReceiver receiver ) {
            this.id = id;
            this.receiver = receiver;
        }
    }
    internal class ParseCell {
        public int id = -1;
        public int command;
        public byte[] data;

        public ParseCell( int id, int command, byte[] data ) {
            this.id = id;
            this.command = command;
            this.data = data;
        }
    }
    public List<TargetID> targets;
    public void Parse( byte[] data ) {
        byte q = ( byte )';';
        byte[] cell;
        for( int i = 0, j = 0; i < data.Length; i++ ) {
            if ( data[ i ] == q ) {
                cell = new byte[ j + 1 ];
                int destinationID = BitConverter.ToInt32( data, i - j  );
                int commandIndex = BitConverter.ToInt32( data, i - j + 4 );
                Buffer.BlockCopy( data, i - j + 8, cell, 0, cell.Length - 9 );
                ParseCell parseCell = new ParseCell( destinationID, commandIndex, cell );
                ProceedParseCell( parseCell );
                j = 0;
            } else {
                j++;
            }
        }
    }

    private void ProceedParseCell( ParseCell parseCell ) {
        // Do something with commands
        int targetIDIndex = targets.FindIndex( ( cell ) => cell.id == parseCell.id );

        if ( targetIDIndex != -1 ) {
            SimplePlayerReceiver receiver = targets[ targetIDIndex ].receiver;
            switch ( parseCell.command ) {
                case 0:
                    receiver.AppendPosition( parseCell.data );
                    break;
                case 1:
                    receiver.AppendRotation( parseCell.data );
                    break;
                case 2:
                    receiver.AppendLocalRotation( parseCell.data );
                    break;
                case 3:
                    receiver.AppendASCII( parseCell.data );
                    break;
                case 4:
                    receiver.AppendUTF8( parseCell.data );
                    break;
                case 5:
                    receiver.AppendAnimationIndex( parseCell.data );
                    break;
            }
            
        }
    }
}
