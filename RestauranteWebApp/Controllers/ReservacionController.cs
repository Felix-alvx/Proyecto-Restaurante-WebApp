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
    public class ReservacionController : Controller
    {
        private readonly IReservacionLN objReservaciones = new ReservacionLN(); //Conexión con interfaz LogicaNegocio


        //vistas
        public ActionResult ListaReservacion()
        {
            List<SP_ConsReservacion_Result> lstReserva = new List<SP_ConsReservacion_Result>();
            List<M_Reservaciones> lstModeloReservacion = new List<M_Reservaciones>();
            lstReserva = objReservaciones.ConsReservacion();
            foreach (var reserva in lstReserva)
            {
                M_Reservaciones objModeloReserva = new M_Reservaciones();
                objModeloReserva.id_reservacion = reserva.id_reservacion;
                objModeloReserva.ID_cliente = reserva.ID_cliente;
                objModeloReserva.ID_mesa = reserva.ID_mesa;
                objModeloReserva.ID_menu = reserva.ID_menu;
                objModeloReserva.Cantidad = reserva.Cantidad;
                objModeloReserva.Fecha_reservacion = reserva.Fecha_reservacion;
                lstModeloReservacion.Add(objModeloReserva);
            }
            return View(lstModeloReservacion);
        }


        public ActionResult AgregarReservacion()
        {
            return View();
        }

        public ActionResult ModificarReservacion(int id)
        {
            SP_ConsReservacionXID_Result objReserva = new SP_ConsReservacionXID_Result();
            M_Reservaciones objReservacionEnt = new M_Reservaciones();
            objReserva = objReservaciones.consReservaciontXID(id);
            objReservacionEnt.id_reservacion = objReserva.id_reservacion;
            objReservacionEnt.ID_cliente = objReserva.ID_cliente;
            objReservacionEnt.ID_menu = objReserva.ID_menu;
            objReservacionEnt.Cantidad = objReserva.Cantidad;
            objReservacionEnt.Fecha_reservacion = objReserva.Fecha_reservacion;
            return View(objReservacionEnt);
        }
        public ActionResult EliminarReservacion(int id)
        {
            SP_ConsReservacionXID_Result objReserva = new SP_ConsReservacionXID_Result();
            M_Reservaciones objReservacionEnt = new M_Reservaciones();
            objReserva = objReservaciones.consReservaciontXID(id);
            objReservacionEnt.id_reservacion = objReserva.id_reservacion;
            objReservacionEnt.ID_cliente = objReserva.ID_cliente;
            objReservacionEnt.ID_menu = objReserva.ID_menu;
            objReservacionEnt.Cantidad = objReserva.Cantidad;
            objReservacionEnt.Fecha_reservacion = objReserva.Fecha_reservacion;
            return View(objReservacionEnt);
        }

        //Metodos

        public ActionResult IngresarReservacion(Reservaciones objReserva)
        {
            List<SP_ConsReservacion_Result> lstReserva = new List<SP_ConsReservacion_Result>();
            List<M_Reservaciones> lstModeloReservacion = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.insReservacion(objReserva))
                {
                    lstReserva = objReservaciones.ConsReservacion();
                    foreach (var reserva in lstReserva)
                    {
                        M_Reservaciones objModeloReserva = new M_Reservaciones();
                        objModeloReserva.id_reservacion = reserva.id_reservacion;
                        objModeloReserva.ID_cliente = reserva.ID_cliente;
                        objModeloReserva.ID_mesa = reserva.ID_mesa;
                        objModeloReserva.ID_menu = reserva.ID_menu;
                        objModeloReserva.Cantidad = reserva.Cantidad;
                        objModeloReserva.Fecha_reservacion = reserva.Fecha_reservacion;
                        lstModeloReservacion.Add(objModeloReserva);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaReservacion", lstModeloReservacion);
        }
        public ActionResult ModificaReservacion(Reservaciones objReserva)
        {
            List<SP_ConsReservacion_Result> lstReserva = new List<SP_ConsReservacion_Result>();
            List<M_Reservaciones> lstModeloReservacion = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.actualizaReservacion(objReserva))
                {
                    lstReserva = objReservaciones.ConsReservacion();
                    foreach (var reserva in lstReserva)
                    {
                        M_Reservaciones objModeloReserva = new M_Reservaciones();
                        objModeloReserva.id_reservacion = reserva.id_reservacion;
                        objModeloReserva.ID_cliente = reserva.ID_cliente;
                        objModeloReserva.ID_mesa = reserva.ID_mesa;
                        objModeloReserva.ID_menu = reserva.ID_menu;
                        objModeloReserva.Cantidad = reserva.Cantidad;
                        objModeloReserva.Fecha_reservacion = reserva.Fecha_reservacion;
                        lstModeloReservacion.Add(objModeloReserva);
                    }

                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaReservacion", lstModeloReservacion);
        }

        public ActionResult EliminaReservacion(Reservaciones objReserva)
        {
            List<SP_ConsReservacion_Result> lstReserva = new List<SP_ConsReservacion_Result>();
            List<M_Reservaciones> lstModeloReservacion = new List<M_Reservaciones>();
            try
            {
                if (objReservaciones.eliminarReservacion(objReserva))
                {
                    lstReserva = objReservaciones.ConsReservacion();
                    foreach (var reserva in lstReserva)
                    {
                        M_Reservaciones objModeloReserva = new M_Reservaciones();
                        objModeloReserva.id_reservacion = reserva.id_reservacion;
                        objModeloReserva.ID_cliente = reserva.ID_cliente;
                        objModeloReserva.ID_mesa = reserva.ID_mesa;
                        objModeloReserva.ID_menu = reserva.ID_menu;
                        objModeloReserva.Cantidad = reserva.Cantidad;
                        objModeloReserva.Fecha_reservacion = reserva.Fecha_reservacion;
                        lstModeloReservacion.Add(objModeloReserva);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaReservacion", lstModeloReservacion);
        }



        //Metodo para conectarse a la web

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Reservaciones pReserva)
        {
            try
            {
                Reservaciones objReservacion = new Reservaciones();
                objReservacion.id_reservacion = pReserva.id_reservacion;
                objReservacion.ID_cliente = pReserva.ID_cliente;
                objReservacion.ID_mesa = pReserva.ID_mesa;
                objReservacion.ID_menu = pReserva.ID_menu;
                objReservacion.Cantidad = pReserva.Cantidad;
                objReservacion.Fecha_reservacion = pReserva.Fecha_reservacion;
                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarReservacion(objReservacion);

                    case "Actualizar":
                        return ModificaReservacion(objReservacion);
                    case "Eliminar":
                        return EliminaReservacion(objReservacion);



                    default:

                        return RedirectToAction("ListaReservacion");
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservacion", "Acciones"));
            }
        }
    }
}