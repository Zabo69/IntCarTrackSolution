using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IntCarTrack.IntCartrackCl x = new IntCarTrack.IntCartrackCl(File.ReadAllText(@"pedidocartrack.json"));
            string y=x.Process();
            Console.WriteLine(y);
        }
    }
}
