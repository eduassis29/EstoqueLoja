using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.WEB.Controllers {

    [AuthorizeSession]
    public class ItensEstoqueController : Controller {

        private readonly IItensEstoqueRepository _IItensRepository;

        public ItensEstoqueController(IItensEstoqueRepository itensEstoqueRepository) {
            _IItensRepository = itensEstoqueRepository;
        }

        // GET: UsuarioController
        public ActionResult Index() {
            return View(_IItensRepository.GetAll());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id) {
            return View(_IItensRepository.GetByIdLoja(id));
        }

        // GET: UsuarioController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItensEstoque collection) {
            try {
                _IItensRepository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id) {
            return View(_IItensRepository.GetByIdLoja(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItensEstoque collection) {
            try {
                _IItensRepository.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id) {
            return View(_IItensRepository.GetByIdLoja(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ItensEstoque collection) {
            try {
                _IItensRepository.Delete(collection);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
