using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos.Interfaz
{
    public interface IMenuAD
    {

        List<SP_ConsMenu_Result> consMenu();
        SP_ConsMenuXID_Result consMenuXID(int pId);
        bool insMenu(Menu pobjMenu);
        bool ActualizaMenu(Menu pobjMenu);
        bool EliminaMenu(Menu pobjMenu);
    }
}
