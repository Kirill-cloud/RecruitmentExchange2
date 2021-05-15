using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.Model
{
    public class Deal
    {
        public int Id { get; set; }
        public Applicant Applicant { get; set; }
        public Vacancy Vacancy{ get; set; }
    }
}
