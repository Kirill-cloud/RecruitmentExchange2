using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class EditApplicantVM : TabViewBase
    {
        public override string TabName { get; set; }
        Applicant applicant;
        ApplicantVM origin;
        public EditApplicantVM(Applicant applicant,ApplicantVM origin)
        {
            this.origin = origin;
            this.applicant = applicant;

        }
    }
}
