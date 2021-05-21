using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class RemoveApplicantVM : TabViewBase
    {
        private Applicant selected;
        private ApplicantVM applicantVM;

        public RemoveApplicantVM(Applicant selected, ApplicantVM applicantVM)
        {
            this.selected = selected;
            this.applicantVM = applicantVM;
        }

        public override string TabName { get; set; } = "удалть искателя приключений";
    }
}
