using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using System.ComponentModel;

namespace CRUD1.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoData _ContactoData = new ContactoData();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de contactos
            var oLista = _ContactoData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            //Solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ContactoModel oContacto)
        {
            //Recibe el objeto para guardarlo en la DB
            if(!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoData.Crear(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idContacto)
        {
            //Solo devuelve la vista
            var oContacto = _ContactoData.Obtener(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //Recibe el objeto para editarlo
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoData.Editar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idContacto)
        {
            //Solo devuelve la vista
            var oContacto = _ContactoData.Obtener(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {          
            var respuesta = _ContactoData.Eliminar(oContacto.idContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
