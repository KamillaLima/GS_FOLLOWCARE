
using Microsoft.AspNetCore.Mvc;
using GS_Fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace GS_Fiap.Controllers
{
    public class MedicoController : Controller
    {
        private Contexto _contexto;

        public MedicoController(Contexto context)
        {
            _contexto = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            _contexto.Medicos.Add(medico);
            _contexto.SaveChanges();
            TempData["msg"] = "Médico registrado com sucesso!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Index()
        {
            var medicosCadastrados = _contexto.Medicos.ToList();
            return View(medicosCadastrados);
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
           
            var medicoEditar = _contexto.Medicos.Find(id);
            return View(medicoEditar);
        }

        [HttpPost]
        public IActionResult Editar(Medico medicoEditar)
        {
            _contexto.Medicos.Update(medicoEditar);
            _contexto.SaveChanges();
            TempData["msg"] = "Médico editado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {

            var medicoRemover = _contexto.Medicos.Find(id);
            _contexto.Medicos.Remove(medicoRemover);
            _contexto.SaveChanges();
            TempData["msg"] = "Médico removido!";
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Pesquisa(string nomePesquisa)
        {
            var medicosEncontrados = _contexto.Medicos
                .Where(m => m.Especialidade.Contains(nomePesquisa))
                .ToList();

            return View(medicosEncontrados);
        }





}
}
