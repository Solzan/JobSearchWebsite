using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labnet.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "JobTitle")]
        public string JobTitle { get; set; }
 
        public string JobDescription { set; get; }

       
        public DateTime StartDate { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { set; get; }

        [Required]
        [Display(Name = "SalaryFrom")]
        public int? SalaryFrom { get; set; }
        
        [Required]
        [Display(Name = "SalaryTo")]
        public int? SalaryTo { get; set; }

        public string Location { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string Company { get; set; }
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
