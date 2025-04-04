using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Interfaz;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementaciones
{
    public class ClienteLN:IClientesLN
    {
        public static RestauranteEntities _gobjContextoNW = new RestauranteEntities(); //Instancia de objEntiti Framework(RestauranteEntities)
        private readonly IClienteAD _objClientesAD = new ClientesAD(_gobjContextoNW);

        public List<SP_ConsCliente_Result> ConsClientes()
        {
            List<SP_ConsCliente_Result> lobjRespuesta = new List<SP_ConsCliente_Result>();
            try
            {
                lobjRespuesta = _objClientesAD.consCliente(); //Método definido en AccesoDatos
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return lobjRespuesta;
        }

        public SP_ConsClienteXID_Result consClientestXID(int pId)
        {
            SP_ConsClienteXID_Result objRespuesta = new SP_ConsClienteXID_Result();
            try
            {
                objRespuesta = _objClientesAD.consClienteXID(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insClientes(Clientes pobjClientes)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _objClientesAD.insClientes(pobjClientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool actualizaClientes(Clientes pobjClientes)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objClientesAD.ActualizaClientes(pobjClientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool eliminarClientes(Clientes pobjCliente)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objClientesAD.EliminaClientes(pobjCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

    }
}
