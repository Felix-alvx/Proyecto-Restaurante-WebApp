using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface IClientesLN
    {
        List<SP_ConsCliente_Result> ConsClientes();
        SP_ConsClienteXID_Result consClientestXID(int pId);
        bool insClientes(Clientes pobjClientes);
        bool actualizaClientes(Clientes pobjClientes);
        bool eliminarClientes(Clientes pobjCliente);
    }
}
