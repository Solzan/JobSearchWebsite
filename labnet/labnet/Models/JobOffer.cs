using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labnet.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string Location { get; set; }
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
