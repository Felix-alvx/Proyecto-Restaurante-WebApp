using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IMesaAD
    {
        List<SP_ConsMesa_Result> consMesa();
        SP_ConsMesaXID_Result consMesaXID(int pId);
        bool insMesa(Mesa pobjMesa);
        bool ActualizaMesa(Mesa pobjMesa);
        bool EliminaMesa(Mesa pobjMesa);
    }
}
