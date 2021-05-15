using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FocusedOn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
