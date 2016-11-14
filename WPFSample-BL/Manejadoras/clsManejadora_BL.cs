using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_Ent;
using WPFSample_DAL.Manejadoras;
using WPFSample_BL.Manejadoras;

namespace WPFSample_BL.Manejadoras
{
    public class clsManejadora_BL
    {
        /// <summary>
        /// Insertar una persona
        /// </summary>
        /// <param name="miPersona"></param>
        /// <returns></returns>
        public int insertarPersonaBL (clsPersona miPersona)
        {
            int i = new clsManejadora_DAL().insertarPersonaDAL(miPersona);
            return i;
        }

    } //Fin class
}
