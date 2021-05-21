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
        public int ApplicantId { get; set; }
        public virtual Vacancy Vacancy{ get; set; }
        public int VacancyId { get; set; }
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
        public Decimal Profit { get; set; }
    }
}
