using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using labnet.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using labnet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labnet.Controllers
{
    [Route("api/[controller]")]
    public class Job : ControllerBase
    {
        private readonly DataContext _context;

        public Job(DataContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<JobOffer> Get()
        {
            return _context.JobOfers.ToList();
        }
    

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JobOffer Get(int id)
        {
            
            return  _context.JobOfers.FirstOrDefault(m => m.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
