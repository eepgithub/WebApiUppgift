using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAuth.Data;

namespace WebApiWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuearyController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public QuearyController(SqlDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetIssues([FromQuery] string status, int Id, DateTime date)
        {
            var quarable = _context.Issues.AsQueryable();
            if (!string.IsNullOrEmpty(status))
                quarable = quarable.Where(q => q.Status == status);

            if (Id >= 1)
                quarable = quarable.Where(q => q.Id == Id);

            if (date != DateTime.MinValue)
                quarable = quarable.Where(q => q.Created.Date == date);

            return new OkObjectResult(await quarable.ToListAsync());
        }


    }
}
