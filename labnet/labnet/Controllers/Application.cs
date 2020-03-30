﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using labnet.Models;
using labnet.EntityFramework;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labnet.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Application : Controller
    {
        private readonly DataContext _context;
        /// <summary>
        /// 
        /// </summary>
        public Application(DataContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        /// <summary>
        /// Get all Applications from the DB
        /// </summary>
        /// <returns>All elements will be returned</returns>
        [HttpGet]
        public IEnumerable<JobApplication> Get()
        {
            return _context.JobApplications.ToList();
        }


        // GET api/<controller>/5
        /// <summary>
        /// Get one Application
        /// </summary>
        /// <remarks>Sample remarks for get one element</remarks>
        /// <param name="id">Id of the element</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JobApplication Get(int id)
        {

            return _context.JobApplications.FirstOrDefault(m => m.Id == id);
        }


        // POST api/<controller>
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
