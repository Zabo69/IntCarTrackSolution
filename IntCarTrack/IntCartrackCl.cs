using IntCarTrack;
using IntCarTrackInterface;
using Newtonsoft.Json;
using RestWsAutarquias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntCarTrack
{
    public class retorno
    {
        public string valor = "";
        public string mensagem = "";
    }
    public class IntCartrackCl
    {

       static public Log Flog = new RestWsAutarquias.Log(@"c:\temp\" + DateTime.Now.ToString("yyyyMMdd") + "loginicial");
        public bool DEBUG = true;
            //   public Configuration CallerConf;
            Rootobject _process;

            public string code;
            public string message;
            public IntCartrackCl(string JSON)
            {
           
            try
                {
                   
                    if (JSON.Substring(0, 1) == "'")
                        JSON = JSON.Substring(1, JSON.Length - 2);
                    //   sigmaClass.Flog = new Log(@"\\aguia\geradocstemp\" + DateTime.Now.ToString("yyyyMMdd") + "logfile.log");
                    //   sigmaClass.Flog.escreve(JSON);
                    _process = JsonConvert.DeserializeObject<Rootobject>(JSON);
                }
                catch (Exception ex)
                {

                    Flog.escreve(DateTime.Now.ToString() + "-->PayIntCl:New(json):" + ex.Message + '\n' + JSON);
                }

            }
            public string Process()
            {


                string _provider;
                string retorno = "";

                if (_process != null && _process.provider.nome.Length > 0)
                {
                   
                    Flog = new RestWsAutarquias.Log((_process.log.Length > 0) ? _process.log + DateTime.Now.ToString("yyyyMMdd") + "logfile.log" : DateTime.Now.ToString("yyyyMMdd") + "logfile.log");
                    DEBUG = Convert.ToBoolean(ConfigurationManager.AppSettings["DEBUG"]);



                    _provider = _process.provider.nome;
                    switch (_provider.ToUpper())
                    {
                        case "CARTRACK":
                            CarTrackCl _cartrack  = new CarTrackCl();
                            retorno RET;
                            RET = _cartrack.Process(_process);

                              
                            this.code = RET.valor;
                            this.message = RET.mensagem;
                            break;
                       
                    }
                }
                else
                {
                    this.code = "-3";
                    this.message = "JSON inválido";
                }

                return this.code + "|" + this.message;
            }
        }
    

}
