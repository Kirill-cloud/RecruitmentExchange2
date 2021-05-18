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
        public List<Applicant> Applicants { get { return DBMethods.GetAllApplicants(); } }
        public ApplicantVM()
        {
            state = new IdleApplicant() { DataContext = this};
        }
        public override RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
