using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class ApplicantVM : TabViewBase
    {
        public override string TabName { get; set; } = "Соискатели";

        public List<Applicant> Applicants { get { return DBMethods.GetAllApplicants(); } }
        public TabViewBase State { get; set; }

        public ApplicantVM()
        {
            State = this;
        }
        public RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
