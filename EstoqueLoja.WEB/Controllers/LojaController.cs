﻿using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.WEB.Controllers {

    [AuthorizeSession]
    public class LojaController : Controller {
        private readonly ILojaRepository _lojaRepository;

        public LojaController(ILojaRepository lojaRepository) {
            _lojaRepository = lojaRepository;
        }

        // GET: UsuarioController
        public ActionResult Index() {
            return View(_lojaRepository.GetAll());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id) {
            return View(_lojaRepository.GetById(id));
        }

        // GET: UsuarioController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loja collection) { 
            try {
                _lojaRepository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id) {
            return View(_lojaRepository.GetById(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loja collection) {
            try {
                _lojaRepository.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id) {
            return View(_lojaRepository.GetById(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loja collection) {
            try {
                _lojaRepository.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
