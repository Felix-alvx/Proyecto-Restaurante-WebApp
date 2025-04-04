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
    public class MenuLN: IMenuLN
    {

        public static RestauranteEntities _gobjContextoNW = new RestauranteEntities();
        private readonly MenuAD _objMenuAD = new MenuAD(_gobjContextoNW);

        public List<SP_ConsMenu_Result> ConsMenu()
        {
            List<SP_ConsMenu_Result> lobjRespuesta = new List<SP_ConsMenu_Result>();
            try
            {
                lobjRespuesta = _objMenuAD.consMenu(); //##
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public SP_ConsMenuXID_Result consMenutXID(int pId)
        {
            SP_ConsMenuXID_Result objRespuesta = new SP_ConsMenuXID_Result();
            try
            {
                objRespuesta = _objMenuAD.consMenuXID(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = _objMenuAD.insMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool actualizaMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objMenuAD.ActualizaMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool eliminarMenu(Menu pobjMenu)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objMenuAD.EliminaMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
    }
}
