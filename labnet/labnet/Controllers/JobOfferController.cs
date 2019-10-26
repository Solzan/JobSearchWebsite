using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using labnet.Models;

namespace labnet.Controllers
{
    public class JobOfferController : Controller
    {

        private static List<JobOffer> _jobOffers = new List<JobOffer>
        {
            new JobOffer{Id=1, JobTitle= "Backend Developer" },
            new JobOffer{Id=1, JobTitle= "Frontend Developer" },
            new JobOffer{Id=1, JobTitle= "Manager" },
            new JobOffer{Id=1, JobTitle= "Cook" }
        };


        [Route("joboffer/index")]
        public IActionResult Index()
        {
            
            return View(_jobOffers);
        }
    }
}