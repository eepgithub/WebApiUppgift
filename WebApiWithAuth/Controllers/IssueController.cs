using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAuth.Models;
using WebApiWithAuth.Services;

namespace WebApiWithAuth.Controllers
{
    [Route("v1")]
    [ApiController]
    public class IssueController : ControllerBase
    {

        private readonly IIdentityService _services;

        public IssueController(IIdentityService services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddIssues")]
        public ActionResult<IssueModel> AddIssues(IssueModel items)
        {
            var issues = _services.AddIssues(items);


            if (issues == null)
            {
                return NotFound();
            }

            return issues;
        }



        [HttpGet]
        [Route("GetIssues")]
        public ActionResult<Dictionary<string, IssueModel>> GetIssues()
        {
            var issueModel = _services.GetIssues();

            if (issueModel.Count == 0)
            {
                return NotFound();
            }

            return issueModel;
        }


    }
}
