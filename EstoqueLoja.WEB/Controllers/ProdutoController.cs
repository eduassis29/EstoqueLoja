using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.WEB.Controllers {
    public class ProdutoController : Controller {
        private readonly IProdutoRepository _IProdutoRepository;

        public ProdutoController(IProdutoRepository produtoRepository) {
            _IProdutoRepository = produtoRepository;
        }

        // GET: UsuarioController
        public ActionResult Index() {
            return View(_IProdutoRepository.GetAll());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id) {
            return View(_IProdutoRepository.GetById(id));
        }

        // GET: UsuarioController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto collection) {
            try {
                _IProdutoRepository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id) {
            return View(_IProdutoRepository.GetById(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produto collection) {
            try {
                _IProdutoRepository.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id) {
            return View(_IProdutoRepository.GetById(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produto collection) {
            try {
                _IProdutoRepository.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
