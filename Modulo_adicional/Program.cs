using System;
using System.IO;
using System.Diagnostics;

namespace Modulo_adicional
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                LoadByCSV loader = new LoadByCSV();
                loader.PerformOperation();
            }
            catch(FormatException)
            {
                Console.WriteLine("Wrong type of input");
            }
            catch(OverflowException)
            {
                Console.WriteLine("This number is to large");
            }
        }
    }
}