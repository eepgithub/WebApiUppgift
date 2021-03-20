using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAuth.Data;
using WebApiWithAuth.Models;
using WebApiWithAuth.Services;

namespace WebApiWithAuth.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private readonly IIdentityService _identity;


        public IssueController(SqlDbContext context, IIdentityService identity)
        {
            _context = context;
            _identity = identity;
        }
       

        [HttpPost("Add")]
        public async Task<IActionResult> AddIssue([FromBody] AddIssueModel model)
        {
            if (await _identity.AddIssueAsync(model))
                return new OkResult();

            return new BadRequestResult();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetErrandIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var Issue = await _context.Issues.FindAsync(id);

            if (Issue == null)
            {
                return NotFound();
            }

            return Issue;
        }




    }
}
