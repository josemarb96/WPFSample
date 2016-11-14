using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WPFSample_BL.Listados;
using WPFSample_BL.Manejadoras;
using WPFSample_Ent;

namespace WPFSample_UI.Controllers
{
    public class HomeController:Controller
    {
        // GET: Home
        /*public ActionResult Index()
        {
            //View vista = new View();

            //try
            //{
            //    clsListadosBL misListados = new clsListadosBL();

            //    vista.ClientID (misListados.listadoPersonasBL());

            //}
            //catch(Exception e) { throw e; }


            //return View(misListados.listadoPersonasBL());

            clsListados_BL misListados = new clsListados_BL();
            return View(misListados.getListadoPersonasBL());
        }

        // GET: Home
        /*public ActionResult Index()
        {
            clsListados_BL vista = new clsListados_BL();

            try
            {
                return View(oListadosBL.getListadoPersonasBL());

            }
            catch (Exception e) { throw e; }

            clsListados_BL misListados = new clsListados_BL();
            return View(misListados.getListadoPersonasBL());
        }*/

        //GET:Home

        public ActionResult Index()
        {
            clsListados_BL lista = new clsListados_BL();
            return View(lista.getListadoPersonasBL());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(clsPersona persona)
        {
            int i;
            clsListados_BL lista = new clsListados_BL();
            if (!ModelState.IsValid)
                return View(persona);
            else
            {
                try
                {
                    i = new clsManejadora_BL().insertarPersonaBL(persona);
                    return View("Index", lista.getListadoPersonasBL());
                }
                catch (Exception)
                {
                    throw;
                    //return View("PagError");
                }
            }
        } //Fin Create Persona

    } //Fin HomeController:Controller
}