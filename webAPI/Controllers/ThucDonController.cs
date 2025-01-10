using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThucDonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThucDonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetThucDon()
        {
            var thucdon = await _context.ThucDon.ToListAsync();
            return Ok(thucdon);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                _context.ThucDon.Add(thucDon);
                await _context.SaveChangesAsync();
                return new JsonResult("them thanh cong");
            }
            return new JsonResult("them that bai");
        }
        [HttpPut]
        public async Task<IActionResult> Edit(ThucDon thucDon)
        {
            var TD = await _context.ThucDon.FindAsync(thucDon.Mathucdon);
            if (TD == null) { return NotFound(); }

            TD.Tenthucdon = thucDon.Tenthucdon;

            await _context.SaveChangesAsync();
            return new JsonResult("them thanh cong");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var TD = await _context.ThucDon.FindAsync(id);
            if(TD == null) { return NotFound(); }

            _context.ThucDon.Remove(TD);
            await _context.SaveChangesAsync();
            return Ok("Xoa thanh cong");
        }
    }
}

