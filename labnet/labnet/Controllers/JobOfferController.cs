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
                SalaryFrom=16000, SalaryTo=20000, StartDate=new DateTime(2020,6,6), EndDate=new DateTime(2020,7,6),Location="Warszaw,Poland" },
            new JobOffer{Id=2, JobTitle= "Frontend Developer",JobDescription="We are looking to hire a Front End Developer  with Angular 2+ to help build out the web and mobile apps.",
                SalaryFrom=12000, SalaryTo=20000, StartDate=new DateTime(2020,6,6), EndDate=new DateTime(2020,6,7),Location="Prague,Czech"},
            new JobOffer{Id=3, JobTitle= "Manager", JobDescription="We are looking for Mannager",SalaryFrom=16000,SalaryTo=18000,
                StartDate =new DateTime(2020,6,6), EndDate =new DateTime(2020,6,7), Location="Paris,France"  },
            new JobOffer{Id=4, JobTitle= "Cook",JobDescription="We are looking for Cook",  SalaryFrom=16000, SalaryTo=18000,
                StartDate =new DateTime(2020,6,6), EndDate =new DateTime(2020,6,7), Location="Moscow,Russia" }
        };


        [Route("joboffer/index")]
        public IActionResult Index()
        {

            return View(_jobOffers);
        }
        public IActionResult Details(int id)
        {
            var offer = _jobOffers.FirstOrDefault(k => k.Id == id);
            var appList= 
            return View(offer);
        }
    }
}