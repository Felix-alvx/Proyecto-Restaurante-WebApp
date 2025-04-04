using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaz;
using Entidades;

namespace AccesoDatos.Implementacion
{
    public class MenuAD: IMenuAD
    {
        private RestauranteEntities gobjContextoAW;

        public MenuAD(RestauranteEntities _gobjContextoNW)
        {
            this.gobjContextoAW = _gobjContextoNW;
        }

        //Método que trae la lista de Menu de la base de datos por medio de un SP (Capa de Seguridad)

        public List<SP_ConsMenu_Result> consMenu()
        {
            List<SP_ConsMenu_Result> lobjRespuesta = new List<SP_ConsMenu_Result>();

            try
            {
                lobjRespuesta = gobjContextoAW.SP_ConsMenu().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;

        }
        //Llamar por ID Menu
        public SP_ConsMenuXID_Result consMenuXID(int pId)
        {
            SP_ConsMenuXID_Result objRespuesta = new SP_ConsMenuXID_Result();

            try
            {
                objRespuesta = gobjContextoAW.SP_ConsMenuXID(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        //Metdodo Insertar Menu
        public bool insMenu(Menu pobjMenu)

        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoAW.SP_InsertarMenu(pobjMenu.Precio, pobjMenu.Descripcion);

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
        public bool ActualizaMenu(Menu pobjMenu)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = gobjContextoAW.SP_ActualizarMenu(pobjMenu.id_menu, pobjMenu.Precio, pobjMenu.Descripcion);
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
        public bool EliminaMenu(Menu pobjMenu)
        {
            var proxyCreationEnable = gobjContextoAW.Configuration.ProxyCreationEnabled;
            bool objRespuesta = false;
            try
            {
                int intVal = 0;
                intVal = gobjContextoAW.SP_EliminarMenu(pobjMenu.id_menu);
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
