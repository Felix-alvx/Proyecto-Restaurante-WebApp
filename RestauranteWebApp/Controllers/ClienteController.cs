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
    public class ClienteController : Controller
    {
        private readonly IClientesLN objClientes = new ClienteLN(); //Conexion con interfaz LogicaNegocio

        //vistas
        public ActionResult ListaClientes()
        {
            List<SP_ConsCliente_Result> lstClientes = new List<SP_ConsCliente_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();

            lstClientes = objClientes.ConsClientes(); //llama al metodo definido en LN 

            foreach (var cliente in lstClientes)
            {
                M_Cliente objModeloCliente = new M_Cliente();
                objModeloCliente.id_Cliente = cliente.id_Cliente;
                objModeloCliente.Nombre = cliente.Nombre;
                objModeloCliente.Apellidos = cliente.Apellidos;
                objModeloCliente.Telefono = cliente.Telefono;
                objModeloCliente.Correo_Electronico = cliente.Correo_Electronico;
                lstModeloCliente.Add(objModeloCliente);

            }
            return View(lstModeloCliente);
        }


        public ActionResult AgregarClientes()
        {
            return View();
        }

        public ActionResult ModificarCliente(int id)
        {
            SP_ConsClienteXID_Result objCliente = new SP_ConsClienteXID_Result();
            M_Cliente objClienteEnt = new M_Cliente();
            objCliente = objClientes.consClientestXID(id);

            objClienteEnt.id_Cliente = objCliente.id_Cliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellidos = objCliente.Apellidos;
            objClienteEnt.Telefono = objCliente.Telefono;
            objClienteEnt.Correo_Electronico = objCliente.Correo_Electronico;
            return View(objClienteEnt);
        }

        public ActionResult EliminarCliente(int id)
        {
            SP_ConsClienteXID_Result objCliente = new SP_ConsClienteXID_Result();
            M_Cliente objClienteEnt = new M_Cliente();
            objCliente = objClientes.consClientestXID(id);
            objClienteEnt.id_Cliente = objCliente.id_Cliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellidos = objCliente.Apellidos;
            objClienteEnt.Telefono = objCliente.Telefono;
            objClienteEnt.Correo_Electronico = objCliente.Correo_Electronico;
            return View(objClienteEnt);
        }

        //Metodos

        public ActionResult IngresarCliente(Clientes objCliente)
        {
            List<SP_ConsCliente_Result> lstCliente = new List<SP_ConsCliente_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();

            try
            {
                if (objClientes.insClientes(objCliente)) //intenta ins cliente a la BD 
                {
                    lstCliente = objClientes.ConsClientes();               //vuelve a obtener la lista actualizada 
                    foreach (var cliente in lstCliente)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.id_Cliente = cliente.id_Cliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellidos = cliente.Apellidos;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo_Electronico = cliente.Correo_Electronico;
                        lstModeloCliente.Add(objModeloCliente);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloCliente);
        }

        public ActionResult ModificaCliente(Clientes objCliente)
        {
            List<SP_ConsCliente_Result> lstCliente = new List<SP_ConsCliente_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>(); //Constructor del Modelo
            try
            {
                if (objClientes.actualizaClientes(objCliente))
                {
                    lstCliente = objClientes.ConsClientes();
                    foreach (var cliente in lstCliente)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.id_Cliente = cliente.id_Cliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellidos = cliente.Apellidos;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo_Electronico = cliente.Correo_Electronico;
                        lstModeloCliente.Add(objModeloCliente);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloCliente);
        }

        public ActionResult EliminaCliente(Clientes objCliente)
        {
            List<SP_ConsCliente_Result> lstCliente = new List<SP_ConsCliente_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>(); //Constructor del Modelo
            try
            {
                if (objClientes.eliminarClientes(objCliente))
                {
                    lstCliente = objClientes.ConsClientes();
                    foreach (var cliente in lstCliente)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.id_Cliente = cliente.id_Cliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellidos = cliente.Apellidos;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo_Electronico = cliente.Correo_Electronico;
                        lstModeloCliente.Add(objModeloCliente);

                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstModeloCliente);
        }


        //Metodo para conectarse a la web

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Cliente pCliente)
        {
            try
            {
                Clientes objCliente = new Clientes();
                objCliente.id_Cliente = pCliente.id_Cliente;
                objCliente.Nombre = pCliente.Nombre;
                objCliente.Apellidos = pCliente.Apellidos;
                objCliente.Telefono = pCliente.Telefono;
                objCliente.Correo_Electronico = pCliente.Correo_Electronico;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarCliente(objCliente);

                    case "Actualizar":
                        return ModificaCliente(objCliente);
                    case "Eliminar":
                        return EliminaCliente(objCliente);


                    default:

                        return RedirectToAction("ListaClientes");
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cliente", "Acciones"));
            }
        }
    }
}