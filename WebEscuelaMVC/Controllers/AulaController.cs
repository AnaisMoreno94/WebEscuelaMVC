using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Linq;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private readonly DBEscuelaContext contex;
        public AulaController(DBEscuelaContext contex)
        {
            this.contex = contex;
        }

        //Index
        [HttpGet]
        public IActionResult Index()
        {
            var aulas = contex.Aulas.ToList();
            return View(aulas);
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            Aula aula = new Aula();

            return View(aula);
        }
        //Create
        [HttpPost]
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                contex.Aulas.Add(aula);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aula);

        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var aula = contex.Aulas.Find(id);

            if (aula == null) { return NotFound(); }
            else { return View("Delete", aula); }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var aula = contex.Aulas.Find(id);
            if (aula == null) return NotFound();
            else
            {
                contex.Aulas.Remove(aula);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Detail

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var aula = contex.Aulas.Find(id);
            if (aula == null) return NotFound();
            else return View("Detalle", aula);
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var aula = contex.Aulas.Find(id);
            if (aula == null) return NotFound();
            else return View("Edit", aula);
        }
        [HttpPost]
        public ActionResult Edit(Aula aula) 
        {
            if (ModelState.IsValid)
            {
                contex.Entry(aula).State = EntityState.Modified;
                contex.SaveChanges();
                return RedirectToAction("Detail", new {id = aula.Id });
            }
            else return RedirectToAction("Edit", new { id = aula.Id }); // Consultar como puedo hacer para mostrar el mensaje del error en vez de recargar la pagina
        }
    }
}
