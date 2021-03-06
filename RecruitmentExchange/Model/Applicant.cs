using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.Model
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Role Role { get; set; }
        public string Description { get; set; }
        public Decimal Salary{ get; set; }
        public bool IsActive { get; set; }

    }
}
