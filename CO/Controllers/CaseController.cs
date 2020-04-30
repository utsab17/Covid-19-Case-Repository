using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CO.Database;
using CO.Models;
using CO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;

namespace CO.Controllers
{

    [Route("v1/")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _services;

        private readonly ApplicationDbContext _db;

        public CaseController(ICaseService services, ApplicationDbContext db)
        {
            _services = services;
            _db = db;
        }


        [HttpPost]
        [Route("AddCase")]
        public ActionResult<Case> AddCases(Case c)
        {
            _db.Case.Add(new Case
            {
                City = c.City,
                Contact = c.Contact,
                Name = c.Name
            });

            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetCases")]
        public async Task<JsonResult> GetCase()
        {
            return new JsonResult(await _db.Case.ToListAsync());
            //var caseList = _services.GetCases();
            //if (caseList == null) return NotFound();
            //return caseList;
        }


        [HttpDelete]
        [Route("DeleteCase/{id}")]
        public async Task<ActionResult> DeleteCase(int id)
        {
            var caseToBeDeleted = await _db.Case.FirstOrDefaultAsync(u => u.Id == id);
            if (caseToBeDeleted == null) return NotFound();
            _db.Case.Remove(caseToBeDeleted);
            _db.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("UpdateCase/{id}")]
        public async Task<ActionResult> UpdateCase(int id, Case c)
        {
            var caseFromDataBase = await _db.Case.FirstOrDefaultAsync(u => u.Id == id);
            if (caseFromDataBase == null) return NotFound();
            caseFromDataBase.City = c.City;
            caseFromDataBase.Contact = c.Contact;
            caseFromDataBase.Name = c.Name;
            _db.SaveChanges();
            return Ok();
        }
    }
} 