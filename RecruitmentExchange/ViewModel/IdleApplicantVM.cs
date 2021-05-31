using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleApplicantVM : TabContentBase
    {
        public override string TabName { get; set; } = "";

        public Applicant Selected { get; set; }
        List<Applicant> applicants;
        public List<Applicant> Applicants
        {
            get
            {
                return applicants;
            }
            set
            {
                applicants = value;
                OnPropertyChanged(nameof(Applicants));
            }
        }

        public IdleApplicantVM(List<Applicant> applicants)
        {
            Applicants = applicants;
        }
    }
}
