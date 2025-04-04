using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementaciones
{
    public class ReservacionLN:  IReservacionLN
    {
        public static RestauranteEntities _gobjContextoNW = new RestauranteEntities();
        private readonly ReservacionAD _objReservacionAD = new ReservacionAD(_gobjContextoNW);

        public List<SP_ConsReservacion_Result> ConsReservacion()
        {
            List<SP_ConsReservacion_Result> lobjRespuesta = new List<SP_ConsReservacion_Result>();
            try
            {
                lobjRespuesta = _objReservacionAD.consReserva(); //##
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public SP_ConsReservacionXID_Result consReservaciontXID(int pId)
        {
            SP_ConsReservacionXID_Result objRespuesta = new SP_ConsReservacionXID_Result();
            try
            {
                objRespuesta = _objReservacionAD.consReservaXID(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _objReservacionAD.insReservaciones(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool actualizaReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objReservacionAD.ActualizaReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool eliminarReservacion(Reservaciones pobjReservacion)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objReservacionAD.EliminaReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

    }
}
