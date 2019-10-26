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
            new JobOffer{Id=1, JobTitle= "Backend Developer", JobDescription="We are looking for Backend Java Developer",
                RequiredSkils ="2+ years of development experience using Java, HTML, and JavaScript", Salary=16000, StartDate=new DateTime(2020,6,6), Location="Warszaw,Poland" },
            new JobOffer{Id=2, JobTitle= "Frontend Developer",JobDescription="We are looking to hire a Front End Developer  with Angular 2+ to help build out the web and mobile apps.",
                 RequiredSkils="JS framework experience (Angular 2+, React, Vue, etc.)",  Salary=12000, StartDate=new DateTime(2020,6,6), Location="Prague,Czech"},
            new JobOffer{Id=3, JobTitle= "Manager", JobDescription="We are looking for Mannager", RequiredSkils="1+ years experirnce",Salary=16000, StartDate=new DateTime(2020,6,6), Location="Paris,France"  },
            new JobOffer{Id=4, JobTitle= "Cook",JobDescription="We are looking for Cook", RequiredSkils="1+ years experirnce", Salary=16000, StartDate=new DateTime(2020,6,6), Location="Moscow,Russia" }
        };


        [Route("joboffer/index")]
        public IActionResult Index()
        {

            return View(_jobOffers);
        }
        public IActionResult Details(int id)
        {
            var offer = _jobOffers.FirstOrDefault(k => k.Id == id);
            return View(offer);
        }
    }
}