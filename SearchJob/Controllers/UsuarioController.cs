using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Model.Models;

namespace SearchJobWeb.Controllers
{
    
    public class UsuarioController : Controller
    {
        private GerenciadorUsuario gu;
        public UsuarioController() => gu = new GerenciadorUsuario();

        // GET: Usuario
        public IActionResult Index()
        {
            /*List<Usuario> model = gu.ObterTodos();
            if (model.Count == 0)
                model = null;*/
            //return View(model);
            return View();
        }

        // GET: Usuario/Details/5
        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Usuario usuario = gu.ObterById(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("Index");
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
                gu.Adicionar(usuario);
            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Usuario usuario = gu.ObterById(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("Index");
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                ModelState.Remove("Id");
                gu.Editar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public IActionResult DeleteAccount(int? id)
        {
            if (id.HasValue)
            {
                Usuario u = gu.ObterById(id);
                if (u != null)
                    return View(u);
            }
            return RedirectToAction("Index");
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAccount(int id)
        {
            if (ModelState.IsValid)
            {
                gu.Remover(id);
            }
            return RedirectToAction("Index");
        }


        //[HttpPost]
        [ValidateAntiForgeryToken]
        //[HttpPost,Route("Usuario/PesquisarProfissao/{profissao}")]
        [HttpPost]
        public IActionResult PesquisarProfissao(FormPesquisar profissao)
        {
            
            List<Usuario> model = gu.ObterTodosByEmprego(profissao.CampoPesquisar);
            if (model.Count == 0)
                model = null;
            return View(model);
        }        
    }
}