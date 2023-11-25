using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GS_Fiap.Models;

namespace GS_Fiap.Controllers
{
    public class ConsultaController : Controller {


        private Contexto _contexto;

        public ConsultaController(Contexto context)
        {
            _contexto = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarPacientes();
            CarregarMedicos();
            return View();
        }

       
        private void CarregarPacientes()
        {

            var lista = _contexto.Pacientes.ToList();
            ViewBag.paciente = new SelectList(lista, "PacienteId", "Nome");
        }

        private void CarregarMedicos()
        {
            var lista = _contexto.Medicos.ToList();
            ViewBag.medico = new SelectList(lista, "MedicoId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Consulta consulta)
        {
            _contexto.Consultas.Add(consulta);
            _contexto.SaveChanges();
            TempData["msg"] = "Consulta registrada!";
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Index()
        {
            var consultas = _contexto.Consultas
                //puxando o nome do paciente e do médico das consultas já cadastradas
                .Include(c => c.Paciente)  
                .Include(c => c.Medico)    
                .ToList();

            return View(consultas);
        }
    }
}



