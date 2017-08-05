using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActorSakilaReboot.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ActorSakilaReboot.Controllers
{
    public class FilmController : Controller
    {
        private readonly sakilaContext _context;

        public FilmController(sakilaContext context)
        {
            _context = context;
        }


        // GET: /Film/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Film.ToListAsync());
        }
    }
}
