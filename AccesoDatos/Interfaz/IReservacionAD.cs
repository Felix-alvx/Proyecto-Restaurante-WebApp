using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IReservacionAD
    {
        List<SP_ConsReservacion_Result> consReserva();
        SP_ConsReservacionXID_Result consReservaXID(int pId);
        bool insReservaciones(Reservaciones pobjReservacion);
        bool ActualizaReservacion(Reservaciones pobjReservacion);
        bool EliminaReservacion(Reservaciones pobjReservacion);
    }
}
