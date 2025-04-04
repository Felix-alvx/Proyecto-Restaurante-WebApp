using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IClienteAD
    {
        List<SP_ConsCliente_Result> consCliente();
        SP_ConsClienteXID_Result consClienteXID(int pId);
        bool insClientes(Clientes pobjCliente);
        bool ActualizaClientes(Clientes pobjCliente);
        bool EliminaClientes(Clientes pobjCliente);
    }
}
