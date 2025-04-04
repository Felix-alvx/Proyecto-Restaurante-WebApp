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
    public class MenuController : Controller
    {
        private readonly IMenuLN objMenus = new MenuLN(); //Conexion con interfaz LogicaNegocio


        //vistas
        public ActionResult ListaMenu()
        {
            List<SP_ConsMenu_Result> lstMenu = new List<SP_ConsMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            lstMenu = objMenus.ConsMenu();
            foreach (var menus in lstMenu)
            {
                M_Menu objModeloMenu = new M_Menu();
                objModeloMenu.id_menu = menus.id_menu;
                objModeloMenu.Precio = menus.Precio;
                objModeloMenu.Descripcion = menus.Descripcion;
                lstModeloMenu.Add(objModeloMenu);

            }
            return View(lstModeloMenu);
        }


        public ActionResult AgregarMenus()
        {
            return View();
        }

        public ActionResult ModificarMenu(int id)
        {
            SP_ConsMenuXID_Result objMenu = new SP_ConsMenuXID_Result();
            M_Menu objMenuEnt = new M_Menu();
            objMenu = objMenus.consMenutXID(id);
            objMenuEnt.id_menu = objMenu.id_menu;
            objMenuEnt.Precio = objMenu.Precio;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            return View(objMenuEnt);
        }

        public ActionResult EliminarMenu(int id)
        {
            SP_ConsMenuXID_Result objMenu = new SP_ConsMenuXID_Result();
            M_Menu objMenuEnt = new M_Menu();
            objMenu = objMenus.consMenutXID(id);
            objMenuEnt.id_menu = objMenu.id_menu;
            objMenuEnt.Precio = objMenu.Precio;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            return View(objMenuEnt);
        }

        //Metodos

        public ActionResult IngresarMenu(Menu objMenu)
        {
            List<SP_ConsMenu_Result> lstMenu = new List<SP_ConsMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenus.insMenu(objMenu))
                {
                    lstMenu = objMenus.ConsMenu();
                    foreach (var menus in lstMenu)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.id_menu = menus.id_menu;
                        objModeloMenu.Precio = menus.Precio;
                        objModeloMenu.Descripcion = menus.Descripcion;
                        lstModeloMenu.Add(objModeloMenu);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }

        public ActionResult ModificaMenu(Menu objMenu)
        {
            List<SP_ConsMenu_Result> lstMenu = new List<SP_ConsMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenus.actualizaMenu(objMenu))
                {
                    lstMenu = objMenus.ConsMenu();
                    foreach (var menus in lstMenu)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.id_menu = menus.id_menu;
                        objModeloMenu.Precio = menus.Precio;
                        objModeloMenu.Descripcion = menus.Descripcion;
                        lstModeloMenu.Add(objModeloMenu);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }
        public ActionResult EliminaMenu(Menu objMenu)
        {
            List<SP_ConsMenu_Result> lstMenu = new List<SP_ConsMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenus.eliminarMenu(objMenu))
                {
                    lstMenu = objMenus.ConsMenu();
                    foreach (var menus in lstMenu)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.id_menu = menus.id_menu;
                        objModeloMenu.Precio = menus.Precio;
                        objModeloMenu.Descripcion = menus.Descripcion;
                        lstModeloMenu.Add(objModeloMenu);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaMenu", lstModeloMenu);
        }



        //Metodo para conectarse a la web

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Menu pMenu)
        {
            try
            {
                Menu objMenu = new Menu();
                objMenu.id_menu = pMenu.id_menu;
                objMenu.Precio = pMenu.Precio;
                objMenu.Descripcion = pMenu.Descripcion;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarMenu(objMenu);

                    case "Actualizar":
                        return ModificaMenu(objMenu);
                    case "Eliminar":
                        return EliminaMenu(objMenu);


                    default:

                        return RedirectToAction("ListaMenu");
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Menu", "Acciones"));
            }
        }
    }
}