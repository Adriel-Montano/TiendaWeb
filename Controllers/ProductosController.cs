using Microsoft.AspNetCore.Mvc;
using TiendaWeb.Models;
using TiendaWeb.Services;

namespace TiendaWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _svc;

        public ProductosController(ProductoService svc) => _svc = svc;

        // GET: /Productos
        public async Task<IActionResult> Index()
        {
            var lista = await _svc.GetAllAsync();
            return View(lista);
        }

        //  GET: /Productos/Create
        public IActionResult Create() => View();

        // POST: /Productos/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto p)
        {
            if (!ModelState.IsValid) return View(p);
            await _svc.CreateAsync(p);
            return RedirectToAction(nameof(Index));
        }

        //  GET: /Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prod = await _svc.GetByIdAsync(id);
            if (prod is null) return NotFound();
            return View(prod);
        }

        // 🟡 GET: /Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var prod = await _svc.GetByIdAsync(id);
            if (prod is null) return NotFound();
            return View(prod);
        }

        // 🟡 POST: /Productos/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Producto p)
        {
            if (!ModelState.IsValid) return View(p);
            await _svc.UpdateAsync(p);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Productos/Delete/5 (confirmación)
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _svc.GetByIdAsync(id);
            if (prod is null) return NotFound();
            return View(prod);
        }

        //  POST: /Productos/DeleteConfirm
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _svc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
