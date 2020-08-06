using System.Collections.Generic;

namespace IntCarTrackInterface
{
    public class Rootobject
    {
        public Provider provider { get; set; }
       // public Dbaccess dbaccess { get; set; }
        public Operacao operacao { get; set; }
        public string log { get; set; }
    }
    public class Auth
    {
        public string campo { get; set; }
        public string valor { get; set; }
    }

    public class Provider
    {
        public string nome { get; set; }
        public string baseuri { get; set; }
        //public string token { get; set; }
        public List<Auth> auth { get; set; }
    }

    public class ClLastPosition
    {


        public string matricula { get; set; }
        public string evento { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public decimal velocidade { get; set; }
        public decimal odometer { get; set; }
        public string posicao_desc { get; set; }
        public string identificacao { get; set; }
        public string estado { get; set; }


    }


    //public class Dbaccess
    //{
    //    public string dbprovider { get; set; }
    //    public string dbserver { get; set; }
    //    public string dblogin { get; set; }
    //    public string dbpass { get; set; }
    //    public string sigmaviewsdb { get; set; }
    //}

    public class Operacao
    {
        public Auth[] argumentos { get; set; }
        public string accao { get; set; }
        public string modo { get; set; }
    }

}