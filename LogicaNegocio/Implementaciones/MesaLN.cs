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
    public class MesaLN: IMesaLN
    {
        public static RestauranteEntities _gobjContextoNW = new RestauranteEntities();
        private readonly MesaAD _objMesaAD = new MesaAD(_gobjContextoNW);

        public List<SP_ConsMesa_Result> ConsMesa()
        {
            List<SP_ConsMesa_Result> lobjRespuesta = new List<SP_ConsMesa_Result>();
            try
            {
                lobjRespuesta = _objMesaAD.consMesa(); //##
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public SP_ConsMesaXID_Result consMesaXID(int pId)
        {
            SP_ConsMesaXID_Result objRespuesta = new SP_ConsMesaXID_Result();
            try
            {
                objRespuesta = _objMesaAD.consMesaXID(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insMesa(Mesa pobjMesa)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _objMesaAD.insMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool actualizaMesa(Mesa pobjMesa)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objMesaAD.ActualizaMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool eliminarMesa(Mesa pobjMesa)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objMesaAD.EliminaMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }
}
