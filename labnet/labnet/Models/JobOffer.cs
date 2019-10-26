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
        public string RequiredSkils { set; get; }
        public DateTime StartDate { set; get; }
        public int Salary { get; set; }
        public string Location { get; set; }
    }
}
