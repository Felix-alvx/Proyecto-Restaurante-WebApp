using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface IMesaLN
    {
        List<SP_ConsMesa_Result> ConsMesa();
        SP_ConsMesaXID_Result consMesaXID(int pId);
        bool insMesa(Mesa pobjMesa);
        bool actualizaMesa(Mesa pobjMesa);
        bool eliminarMesa(Mesa pobjMesa);
    }
}
