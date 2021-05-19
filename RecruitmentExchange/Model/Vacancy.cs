using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentExchange.AppData;

namespace RecruitmentExchange.Model
{
    public class Vacancy
    {
        public int Id { get; set; }
        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public string Description { get; set; }

    }
}
