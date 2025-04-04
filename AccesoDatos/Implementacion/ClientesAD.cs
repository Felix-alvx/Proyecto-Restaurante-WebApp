using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaz;
using Entidades;

namespace AccesoDatos.Implementacion
{
    public class ClientesAD : IClienteAD
    {
        private RestauranteEntities gobjContextoAW;

        public ClientesAD(RestauranteEntities _gobjContextoNW)
        {
            this.gobjContextoAW = _gobjContextoNW;
        }

        //Método que trae la lista de Clientes de la base de datos por medio de un SP (Capa de Seguridad)

        public List<SP_ConsCliente_Result> consCliente()
        {
            List<SP_ConsCliente_Result> lobjRespuesta = new List<SP_ConsCliente_Result>();

            try
            {
                lobjRespuesta = gobjContextoAW.SP_ConsCliente().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;

        }
        //Llamar por ID
        public SP_ConsClienteXID_Result consClienteXID(int pId)
        {
            SP_ConsClienteXID_Result objRespuesta = new SP_ConsClienteXID_Result();

            try
            {
                objRespuesta = gobjContextoAW.SP_ConsClienteXID(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        //Metdodo Insertar Clientes
        public bool insClientes(Clientes pobjCliente)

        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled; 
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoAW.sp_InsertarCliente(pobjCliente.Nombre, pobjCliente.Apellidos, pobjCliente.Telefono, pobjCliente.Correo_Electronico);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoAW.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
        //Metodo de Actualizar Cliente
        public bool ActualizaClientes(Clientes pobjCliente)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = gobjContextoAW.SP_ActualizarCliente(pobjCliente.id_Cliente, pobjCliente.Nombre, pobjCliente.Apellidos, pobjCliente.Telefono,
                    pobjCliente.Correo_Electronico);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoAW.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
        // metodo Delete Clientes
        public bool EliminaClientes(Clientes pobjCliente)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = false;
            try
            {
                int intVal = 0;
                intVal = gobjContextoAW.SP_EliminarCliente(pobjCliente.id_Cliente);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoAW.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
    }
}
