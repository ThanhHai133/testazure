using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonAnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonAnController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var monan = await _context.MonAn.ToListAsync();
            return Ok(monan);
        }

 
    }
}
