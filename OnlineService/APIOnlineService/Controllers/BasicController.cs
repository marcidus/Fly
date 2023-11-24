using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;


namespace APIOnlineService.Controllers

{
    public class BasicController : Controller
    {

        private readonly ContextBoundObject _context;

        [HttpGet("GetBigProject")]
        public async Task<ActionResult<List<Project>>> GetBigProjects()
        {
            var projetsList = await _context.ProjetSet.Where(f => f.price > 10000000).ToListAsync();
            return projetsList;
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeWorkingFor(Client client)
        {
            var EmployeesList = await _context.EmployeeSet.Where(f = f.client = client.name).ToListAsync();
            return projetsList;
        }

        [HttpGet("GetProject")]
        public async Task<ActionResult<Projet>> GetProject(int id)
        {
            return await _context.ProjetSet.Where(s => s.Projet.IDProjet== IDProjet);
        }

    }
}
