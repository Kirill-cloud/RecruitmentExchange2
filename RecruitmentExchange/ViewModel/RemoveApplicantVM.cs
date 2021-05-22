using RecruitmentExchange.AppData;
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
        private Applicant applicant;
        private readonly ApplicantVM origin;

        public RemoveApplicantVM(Applicant applicant, ApplicantVM origin)
        {
            this.applicant = applicant;
            this.origin = origin;
            TabName += applicant.Name;
        }

        public override string TabName { get; set; } = "Удалить соискателя ";

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    DBMethods db = new();
                    db.RemoveApplicant(applicant);
                    origin.State = origin;
                    origin.Selected = null;
                });
            }
        }

    }
}
