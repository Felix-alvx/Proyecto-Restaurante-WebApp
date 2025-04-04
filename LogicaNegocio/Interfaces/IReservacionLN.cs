using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface IReservacionLN
    {
        List<SP_ConsReservacion_Result> ConsReservacion();
        SP_ConsReservacionXID_Result consReservaciontXID(int pId);
        bool insReservacion(Reservaciones pobjReservacion);
        bool actualizaReservacion(Reservaciones pobjReservacion);
        bool eliminarReservacion(Reservaciones pobjReservacion);
    }
}
