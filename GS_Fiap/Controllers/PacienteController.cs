using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GS_Fiap.Models;
using System.Runtime.Serialization;

namespace GS_Fiap.Controllers
{
    public class PacienteController : Controller
    {
        private Contexto _contexto;

        public PacienteController(Contexto context)
        {
            _contexto = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();
            TempData["msg"] = "Paciente registrado com sucesso!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Index()
        {
            var pacientes = _contexto.Pacientes.ToList();
            return View(pacientes);
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
           
            var pacienteEditar = _contexto.Pacientes.Find(id);
            return View(pacienteEditar);
        }

        [HttpPost]
        public IActionResult Editar(Paciente pacienteEditar)
        {
            _contexto.Pacientes.Update(pacienteEditar);
            _contexto.SaveChanges();
            TempData["msg"] = "Paciente atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var pacienteRemover = _contexto.Pacientes.Find(id);
            _contexto.Pacientes.Remove(pacienteRemover);
            _contexto.SaveChanges();
            TempData["msg"] = "Paciente removido!";
            return RedirectToAction("Index");
        }


       
    }
}
