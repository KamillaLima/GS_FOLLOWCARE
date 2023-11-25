using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GS_Fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace GS_Fiap.Controllers
{
    public class MedicamentoController : Controller
    {
        private Contexto _contexto;

        public MedicamentoController(Contexto context)
        {
            _contexto = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarPacientes();
            return View();
        }

        
        private void CarregarPacientes()
        {
            var listaPacientes = _contexto.Pacientes.ToList();
            ViewBag.paciente = new SelectList(listaPacientes, "PacienteId", "Nome");
        }

        


        [HttpPost]
        public IActionResult Cadastrar(Medicamento medicamento)
        {
            _contexto.Medicamentos.Add(medicamento);
            _contexto.SaveChanges();
            TempData["msg"] = "Medicamento registrado!";
            return RedirectToAction("Cadastrar");
        }




        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Carregar medicamento com efeito colateral
            var medicamentoEditar = _contexto.Medicamentos
                .Include(m => m.EfeitoColateral)
                .FirstOrDefault(m => m.MedicamentoId == id);

            // Carregar a lista de efeitos colaterais
            var listaEfeitos = _contexto.Efeitos.ToList();
            ViewBag.Efeitos = new SelectList(listaEfeitos, "EfeitoId", "Descricao");

            return View(medicamentoEditar);
        }

        [HttpPost]
        public IActionResult Editar(Medicamento medicamentoEditar, int efeitoColateralId, int pacienteId)
        {
            medicamentoEditar.EfeitoColateralId = efeitoColateralId;
            medicamentoEditar.PacienteId = pacienteId;

            _contexto.Medicamentos.Update(medicamentoEditar);
            _contexto.SaveChanges();
            TempData["msg"] = "Medicamento atualizado!";
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Remover(int id)
        {
            var nomeMedicamento = _contexto.Medicamentos.Find(id);
            _contexto.Medicamentos.Remove(nomeMedicamento);
            _contexto.SaveChanges();
            TempData["msg"] = "Medicamento removido!";
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var consultas = _contexto.Medicamentos
                //puxando o nome do paciente e do médico das consultas já cadastradas
                .Include(c => c.Paciente)
                .Include(c => c.EfeitoColateral)
                .ToList();

            return View(consultas);
        }

    }
}
