using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BringYourOwnDeviceWatcher.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BringYourOwnDeviceWatcher.Controllers
{
    [Route("api/[controller]")]
    public class NmapRunController : Controller
    {
        private readonly NmapRunContext _context;

        public NmapRunController(NmapRunContext context)
        {
            _context = context;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NmapRun>> GetRun(int id)
        {
            var item = await _context.NmapRuns.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<NmapRun>> Post([FromBody] NmapRun devices)
        {
            _context.NmapRuns.Add(devices);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRun), new { id = devices.NmapRunId }, devices);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
