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
        public virtual Applicant Applicant { get; set; }
        public virtual Vacancy Vacancy{ get; set; }
        public Decimal Profit { get; set; }
    }
}
