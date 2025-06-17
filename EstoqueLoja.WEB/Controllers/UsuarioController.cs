using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.WEB.Controllers {
    public class UsuarioController : Controller {
        private readonly IUsuarioRepository _IusuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) {
            _IusuarioRepository = usuarioRepository;
        }

        // GET: UsuarioController
        public ActionResult Index() {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id) {
            return View(_IusuarioRepository.GetById(id));
        }

        // GET: UsuarioController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario collection) {
            try {
                _IusuarioRepository.Add(collection);
                return RedirectToAction("Index","Home");
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id) {
            return View(_IusuarioRepository.GetById(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario collection) {
            try {
                _IusuarioRepository.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id) {
            return View(_IusuarioRepository.GetById(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario collection) {
            try {
                _IusuarioRepository.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
