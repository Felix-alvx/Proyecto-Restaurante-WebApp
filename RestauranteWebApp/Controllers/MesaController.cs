using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using LogicaNegocio.Implementaciones;
using LogicaNegocio.Interfaces;
using RestauranteWebApp.Models;

namespace RestauranteWebApp.Controllers
{
    public class MesaController : Controller
    {
        private readonly IMesaLN objMesas = new MesaLN(); //Conexion con interfaz LogicaNegocio


        //vistas
        public ActionResult ListaMesa()
        {
            List<SP_ConsMesa_Result> lstMesa = new List<SP_ConsMesa_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            lstMesa = objMesas.ConsMesa();
            foreach (var mesa in lstMesa)
            {
                M_Mesa objModeloMesa = new M_Mesa();
                objModeloMesa.id_mesa = mesa.id_mesa;
                objModeloMesa.Numero_Mesa = mesa.Numero_Mesa;
                objModeloMesa.Descripcion = mesa.Descripcion;
                lstModeloMesa.Add(objModeloMesa);
            }
            return View(lstModeloMesa);
        }


        public ActionResult AgregarMesas()
        {
            return View();
        }

        public ActionResult ModificarMesa(int id)
        {
            SP_ConsMesaXID_Result objMesa = new SP_ConsMesaXID_Result();
            M_Mesa objMesaEnt = new M_Mesa();
            objMesa = objMesas.consMesaXID(id);
            objMesaEnt.id_mesa = objMesa.id_mesa;
            objMesaEnt.Numero_Mesa = objMesa.Numero_Mesa;
            objMesaEnt.Descripcion = objMesa.Descripcion;
            return View(objMesaEnt);
        }

        public ActionResult EliminarMesa(int id)
        {
            SP_ConsMesaXID_Result objMesa = new SP_ConsMesaXID_Result();
            M_Mesa objMesaEnt = new M_Mesa();
            objMesa = objMesas.consMesaXID(id);
            objMesaEnt.id_mesa = objMesa.id_mesa;
            objMesaEnt.Numero_Mesa = objMesa.Numero_Mesa;
            objMesaEnt.Descripcion = objMesa.Descripcion;
            //#Revisar
            return View(objMesaEnt);
        }

        //Metodos

        public ActionResult IngresarMesa(Mesa objMesa)
        {
            List<SP_ConsMesa_Result> lstMesa = new List<SP_ConsMesa_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            try
            {
                if (objMesas.insMesa(objMesa))
                {
                    lstMesa = objMesas.ConsMesa();
                    foreach (var mesa in lstMesa)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.id_mesa = mesa.id_mesa;
                        objModeloMesa.Numero_Mesa = mesa.Numero_Mesa;
                        objModeloMesa.Descripcion = mesa.Descripcion;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesa", lstModeloMesa);
        }
        public ActionResult ModificaMesa(Mesa objMesa)
        {
            List<SP_ConsMesa_Result> lstMesa = new List<SP_ConsMesa_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();

            try
            {
                if (objMesas.actualizaMesa(objMesa))
                {
                    lstMesa = objMesas.ConsMesa();
                    foreach (var mesa in lstMesa)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.id_mesa = mesa.id_mesa;
                        objModeloMesa.Numero_Mesa = mesa.Numero_Mesa;
                        objModeloMesa.Descripcion = mesa.Descripcion;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesa", lstModeloMesa);
        }

        public ActionResult EliminaMesa(Mesa objMesa)
        {
            List<SP_ConsMesa_Result> lstMesa = new List<SP_ConsMesa_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            try
            {
                if (objMesas.eliminarMesa(objMesa))
                {
                    lstMesa = objMesas.ConsMesa();
                    foreach (var mesa in lstMesa)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.id_mesa = mesa.id_mesa;
                        objModeloMesa.Numero_Mesa = mesa.Numero_Mesa;
                        objModeloMesa.Descripcion = mesa.Descripcion;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMesa", lstModeloMesa);
        }



        //Metodo para conectarse a la web

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Mesa pMesa)
        {
            try
            {
                Mesa objMesa = new Mesa();
                objMesa.id_mesa = pMesa.id_mesa;
                objMesa.Numero_Mesa = pMesa.Numero_Mesa;
                objMesa.Descripcion = pMesa.Descripcion;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarMesa(objMesa);

                    case "Actualizar":
                        return ModificaMesa(objMesa);
                    case "Eliminar":
                        return EliminaMesa(objMesa);


                    default:

                        return RedirectToAction("ListaMesa");
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesa", "Acciones"));
            }
        }
    }
}