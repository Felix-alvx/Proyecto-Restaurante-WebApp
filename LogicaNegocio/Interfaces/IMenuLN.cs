using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface IMenuLN
    {
        List<SP_ConsMenu_Result> ConsMenu();
        SP_ConsMenuXID_Result consMenutXID(int pId);
        bool insMenu(Menu pobjMenu);
        bool actualizaMenu(Menu pobjMenu);
        bool eliminarMenu(Menu pobjMenu);
    }
}
