using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ConsoleApp1
{

    public class ClLastPosition
    {

        
        public string Matricula;
        public string Evento;
        public string latitude;
        public string longitude;
        public decimal velocidade;
        public decimal odometer;
        public string posicao_desc;
        public string identificacao;


    }
    class Program
    {
        static void Main(string[] args)
        {
            IntCarTrack.IntCartrackCl x = new IntCarTrack.IntCartrackCl(File.ReadAllText(@"pedidocartrack .json"));
            x.Process();
        }
    }
}
