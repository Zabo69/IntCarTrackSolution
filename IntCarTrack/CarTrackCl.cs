using IntCarTrack;
using IntCarTrack.CartrackSoap;
using IntCarTrackInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntCarTrack
{
    class CarTrackCl
    {


        public retorno Process(Rootobject pedido)
        {
            endpoint _cartrack;
            retorno RET = new retorno();
            string _retorno;
            Dictionary<string, string> _dic = pedido.provider.auth.ToDictionary(t => t.campo, t => t.valor);
            System.Net.NetworkCredential _cred = new System.Net.NetworkCredential(_dic["user"].Trim(), _dic["pass"]);
            // entityID =  _dic["entityID"];

            RET.valor = "1";
            _retorno = "OK";
            switch (pedido.operacao.accao.ToUpper())
            {
                case "LASTPOSITIONS":


                    List<ClLastPosition> _lastpositions;
                    _cartrack = new CartrackSoap.endpoint();

                    _cartrack.Url = pedido.provider.baseuri;
                    _cartrack.Credentials = _cred;
                    //  refs = GeraRefs(pedido.operacao.idspool);
                    RET = GetLastPosition(_cartrack,pedido.operacao.argumentos,out  _lastpositions);
                    if (RET.valor == "1")
                    {
                        RET.valor = "1";
                        RET.mensagem = Newtonsoft.Json.JsonConvert.SerializeObject(_lastpositions );

                    }
                    //else
                    //{
                    //    RET.valor = "-3";
                    //    RET.mensagem = "Problemas a pedir last positions:" ;
                    //}
                    break;
               
                case "":
                    break;
            }

            //sigmaClass.Flog.escreve(DateTime.Now.ToString() + "->Referências pedidas:" + _MB.PedidosCount.ToString() + " : Referências actualizadas:" + _MB.PedidosProc.ToString());
            return RET;
        }

       private retorno GetLastPosition(CartrackSoap.endpoint _cartrack, Auth[] argumentos, out List<ClLastPosition> posicoes)
        {
            
           
            retorno RET = new retorno();
            posicoes = null;
            try
            {



               
                CartrackSoap.get_all_vehicles_last_positionsResultType0Row[] _pos;
                
                try
                {
                    Dictionary<string, string> _dic = argumentos.ToDictionary(t => t.campo, t => t.valor);

                    string matricula = (_dic["matricula"].Length > 0 ? _dic["matricula"] : "ALL");

                    _pos = _cartrack.endpointget_all_vehicles_last_positions("", matricula);




                    List<ClLastPosition> x=new List<ClLastPosition>();

                    foreach (CartrackSoap.get_all_vehicles_last_positionsResultType0Row _row in _pos)
                    {

                        if (_row.o_registration!="")
                        {
                            x.Add(new ClLastPosition()
                            {
                                evento = _row.o_event_ts,
                                identificacao = _row.o_identification_tag,
                                latitude = _row.o_latitude.ToString(),
                                longitude = _row.o_longitude.ToString(),
                                matricula = _row.o_registration,
                                odometer = _row.o_odometer,
                                posicao_desc = _row.o_position_description,
                                velocidade = _row.o_speed
                            }
                            );
                        }

                    }
                    if (x.Count > 0)
                    {
                        RET.valor = "1";
                        RET.mensagem = "OK";
                       
                    }
                    else
                    {
                        RET.valor = "-2";
                        RET.mensagem = "Não foram retornados registos";
                    }
                    posicoes = x;
                }
                catch (Exception ex)
                {
                    IntCartrackCl.Flog.escreve(DateTime.Now.ToString() + "-->Cartrack.GetLastPositions:Erro: " + ex.Message);
                    RET.valor = "-1";
                    RET.mensagem = "Erro ao pedir últimas posições";

                }

            }
            catch ( Exception ex)
            {

            }
            
            return RET;  
        }
    }
}
