using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaz;
using Entidades;

namespace AccesoDatos.Implementacion
{
    public class ReservacionAD: IReservacionAD
    {
        private RestauranteEntities gobjContextoAW;

        public ReservacionAD(RestauranteEntities _gobjContextoNW)
        {
            this.gobjContextoAW = _gobjContextoNW;
        }

        //Método que trae la lista de Reservaciones de la base de datos por medio de un SP (Capa de Seguridad)

        public List<SP_ConsReservacion_Result> consReserva()
        {
            List<SP_ConsReservacion_Result> lobjRespuesta = new List<SP_ConsReservacion_Result>();

            try
            {
                lobjRespuesta = gobjContextoAW.SP_ConsReservacion().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;

        }
        //Llamar por ID
        public SP_ConsReservacionXID_Result consReservaXID(int pId)
        {
            SP_ConsReservacionXID_Result objRespuesta = new SP_ConsReservacionXID_Result();

            try
            {
                objRespuesta = gobjContextoAW.SP_ConsReservacionXID(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        //Metdodo Insertar Reservaciones
        public bool insReservaciones(Reservaciones pobjReservacion)

        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoAW.SP_InsertarReservacion(pobjReservacion.ID_cliente, pobjReservacion.ID_mesa, pobjReservacion.ID_menu, pobjReservacion.Cantidad,
                    pobjReservacion.Fecha_reservacion);

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
        public bool ActualizaReservacion(Reservaciones pobjReservacion)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = gobjContextoAW.SP_ActualizarReservacion(pobjReservacion.id_reservacion, pobjReservacion.ID_cliente, pobjReservacion.ID_mesa, pobjReservacion.ID_menu, pobjReservacion.Cantidad,
                    pobjReservacion.Fecha_reservacion);
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
        // metodo Delete Reservaciones
        public bool EliminaReservacion(Reservaciones pobjReservacion)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = false;
            try
            {
                int intVal = 0;
                intVal = gobjContextoAW.SP_EliminarReservacion(pobjReservacion.id_reservacion);
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
