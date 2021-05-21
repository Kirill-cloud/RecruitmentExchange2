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
        public string Name { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public string Description { get; set; }
        public double Salary{ get; set; }
        public bool IsActive { get; set; }

    }
}
