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
    public class ApplicantVM : TabViewBase
    {
        public override string TabName { get; set; } = "Соискатели";

        public ApplicantVM()
        {
            State = new IdleApplicantVM();
        }

        public RelayCommand GoAdd => new(obj =>
        {
            if (State is IdleApplicantVM)
            {
                State = new EditApplicantVM(null, this);
            }
        });

        public RelayCommand GoEdit => new(obj =>
        {
            if (State is IdleApplicantVM)
            {
                State = new EditApplicantVM((State as IdleApplicantVM).Selected, this);
            }
        });

        public RelayCommand GoRemove => new(obj =>
        {
            if (State is IdleApplicantVM)
            {
                State = new RemoveApplicantVM((State as IdleApplicantVM).Selected, this);
            }
        });

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new IdleApplicantVM();
                });

            }
        }
    }
}
