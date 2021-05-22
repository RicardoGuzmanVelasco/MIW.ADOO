using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public static class IO
    {
        public static string ReadString(string title)
        {
            string input = null;
            var ok = false;
            do {
                Write(title);
                try
                {
                    input = Console.In.ReadLine();
                    ok = true;
                } catch (Exception) {
                    WriteError("cadena de caracteres");
                }
            } while (!ok);
            return input;
        }
        
        public static int ReadInt(string title)
        {
            var input = 0;
            var ok = false;
            do {
                Write(title);
                try
                {
                    input = int.Parse(Console.In.ReadLine());
                    ok = true;
                } catch (Exception) {
                    WriteError("entero");
                }
            } while (!ok);
            
            return input;
        }

        public static void Write(string title)
        {
            Debug.Log(title);
        }

        public static void WriteLn()
        {
            Debug.Log("\n");
        }

        public static void WriteError(string format)
        {
            Debug.Log("Se esperaba un formato de " + format);
        }
    }
}