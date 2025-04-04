using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaz;
using Entidades;

namespace AccesoDatos.Implementacion
{
    public class MesaAD: IMesaAD
    {
        private RestauranteEntities gobjContextoAW;

        public MesaAD(RestauranteEntities _gobjContextoNW)
        {
            this.gobjContextoAW = _gobjContextoNW;
        }

        //Método que trae la lista de Mesa de la base de datos por medio de un SP (Capa de Seguridad)

        public List<SP_ConsMesa_Result> consMesa()
        {
            List<SP_ConsMesa_Result> lobjRespuesta = new List<SP_ConsMesa_Result>();

            try
            {
                lobjRespuesta = gobjContextoAW.SP_ConsMesa().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;

        }
        //Llamar por ID Mensa
        public SP_ConsMesaXID_Result consMesaXID(int pId)
        {
            SP_ConsMesaXID_Result objRespuesta = new SP_ConsMesaXID_Result();

            try
            {
                objRespuesta = gobjContextoAW.SP_ConsMesaXID(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        //Metdodo Insertar Mesa
        public bool insMesa(Mesa pobjMesa)

        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoAW.SP_InsertarMesa(pobjMesa.Numero_Mesa, pobjMesa.Descripcion);

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
        //Metodo de Actualizar Menu 
        public bool ActualizaMesa(Mesa pobjMesa)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = gobjContextoAW.SP_ActualizarMesa(pobjMesa.id_mesa, pobjMesa.Numero_Mesa, pobjMesa.Descripcion);
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
        // metodo Delete Menu
        public bool EliminaMesa(Mesa pobjMesa)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = false;
            try
            {
                int intVal = 0;
                intVal = gobjContextoAW.SP_EliminarMesa(pobjMesa.id_mesa);
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
