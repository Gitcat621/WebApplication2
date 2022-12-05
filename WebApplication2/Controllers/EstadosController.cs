using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EstadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Estados.ToListAsync();
            return View(response);
        }

        public IActionResult Crear()
        {
            ViewBag.combo = _context.Ciudades.Select(x => new SelectListItem
            {
                Text = x.Ciudad,
                Value = x.PkCiudad.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEstado(Estados request)
        {
            try
            {
                if (request != null)
                {
                    Estados estado = new Estados();
                    estado.Estado = request.Estado;
                    estado.FkCiudad = request.FkCiudad;

                    _context.Estados.Add(estado);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var usuario = _context.Estados.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                else
                    ViewBag.combo = _context.Ciudades.Select(x => new SelectListItem
                    {
                        Text = x.Ciudad,
                        Value = x.PkCiudad.ToString()
                    });
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var Estados = _context.Estados.Find(id);

            _context.Remove(Estados);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
