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

        //Create
        public ActionResult Index()
        {
            clsListados_BL lista = new clsListados_BL();
            return View(lista.getListadoPersonasBL());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //Este es el botón de crear
        public ActionResult Create(clsPersona persona)
        {
            int i;
            clsListados_BL lista = new clsListados_BL();
            if (!ModelState.IsValid) //Sino están todos los campos
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

        public ActionResult Delete(int id) //Cogemos un valor enviado por la ruta de arriba, después lo enviamos a la vista
        {
            return View("Delete");
        }

        [HttpPost, ActionName("Delete")] //Botón de borrar
        public ActionResult DeleteConfirmed(int id)
        {
            clsManejadora_BL miManejadora = new clsManejadora_BL();
            clsListados_BL miLista = new clsListados_BL();
            miManejadora.deletePersonaBL(id); //Se vuelve a coger el campo de la URL, cogiendo de nuevo el id
            return View("Index", miLista.getListadoPersonasBL());
        }

        public ActionResult Edit(int id)
        {
            clsPersona persona = new clsPersona();

            foreach (clsPersona per in new clsListados_BL().getListadoPersonasBL())
            {
                if (per.ID == id)
                {
                    persona.Nombre = per.Nombre;
                    persona.Apellidos = per.Apellidos;
                    persona.FechaNac = per.FechaNac;
                    persona.Telefono = per.Telefono;
                    persona.Direccion = per.Direccion;
                }
            }
            return View(persona);
        }

        /*El tema de poner el id en vez de un objeto persona es porque si por ejemplo el objeto persona no tuviera
         *no tuviera id o este se cambiase a "identificador" por ejemplo, se jode todo, aqui no habria problemas porque coinciden
         * todos los campos. */

        [HttpPost] //Botón de editar, no pongo alias porque recojo los valores que coinciden con los de persona
        public ActionResult Edit(clsPersona persona)
        {
            clsManejadora_BL miManejadora = new clsManejadora_BL();
            miManejadora.updatePersonaBL(persona);

            return View("Index", new clsListados_BL().getListadoPersonasBL());
        }

        public ActionResult Details(int id)
        {
            clsManejadora_BL miMane = new clsManejadora_BL();
            clsPersona persona = miMane.selectPersonaBL(id);
            return View(persona);
        }

    } //Fin HomeController:Controller
}