using System.Runtime.InteropServices;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class Start
    {
        char[,] tokens;
        
        public Start(char[,] tokens)
        {
            this.tokens = tokens;
            
            for(var i = 0; i < 3; i++)
            for(var j = 0; j < 3; j++)
                tokens[i,j] = '_';
        }

        public void Write()
        {
            string board = "";
            
            for(var i = 0; i < 3; i++)
            {
                for(var j = 0; j < 3; j++)
                    board += tokens[i, j] + " ";
                board += "\n";
            }

            Debug.Log(board);
        }
    }
}