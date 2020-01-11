using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using labnet.EntityFramework;
using labnet.Models;
using System.Dynamic;

namespace labnet.Controllers
{
    public class JobOffersController : Controller
    {
        private readonly DataContext _context;

        public JobOffersController(DataContext context)
        {
            _context = context;
        }


        // GET: JobOffers
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobOfers.ToListAsync());
        }

        // GET: JobOffers/Details/5
        [Route("JobOffers/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            var jobApp1 = await _context.JobApplications.ToListAsync();
            List<JobApplication> jobApp = new List<JobApplication>();
            for (int i=0;i<jobApp1.Count;i++)
            {
                if(jobApp1[i].OfferId==id)
                {
                    jobApp.Add(jobApp1[i]);
                }
            }
            Tuple<JobOffer,List<JobApplication>> a = new Tuple<JobOffer,List<JobApplication>>(jobOffer, jobApp);
            return View(a);
        }
        [Route("JobOffers/Create")]
        public async Task<ActionResult> Create()
        {
            var model = new JobOfferCreateView
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(model);
        }
        [Route("JobOffers/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Company,JobDescription,JobTitle, Location, SalaryFrom,SalaryTo, EndDate")] JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = await _context.Companies.ToListAsync();
                return View(model);
            }
            

            JobOffer jo = new JobOffer
            {
                Company = model.Company,
                JobDescription = model.JobDescription,
                JobTitle = model.JobTitle,
                Location = model.Location,
                SalaryFrom = model.SalaryFrom,
                SalaryTo = model.SalaryTo,
                EndDate = model.EndDate,
                StartDate = DateTime.Now
            };
           
                await _context.JobOfers.AddAsync(jo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

        }

        // GET: JobOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOfers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobTitle,JobDescription,StartDate,EndDate,SalaryFrom,SalaryTo,Location,Company")] JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferExists(jobOffer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobOffer = await _context.JobOfers.FindAsync(id);
            _context.JobOfers.Remove(jobOffer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOfers.Any(e => e.Id == id);
        }


        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return PartialView();
        }

    }
}
