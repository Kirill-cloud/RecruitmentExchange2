using System.Collections.Generic;

namespace RecruitmentExchange.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Vacancy> Vacancies { get; set; }
        public virtual List<Applicant> Applicants { get; set; }
    }
}
