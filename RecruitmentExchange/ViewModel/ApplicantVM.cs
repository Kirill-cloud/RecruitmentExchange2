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

        public Applicant Selected { get; set; }

        TabViewBase state;
        public TabViewBase State
        {
            get
            { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public List<Applicant> Applicants
        {
            get
            {
                DBMethods db = new();
                return db.GetAllApplicants();
            }
        }

        public ApplicantVM()
        {
            State = this;
        }
        public RelayCommand GoAdd => new RelayCommand(obj =>
        {
            State = new EditApplicantVM(null,this);
        });

        public RelayCommand GoEdit => new RelayCommand(obj =>
        {
            State = new EditApplicantVM(Selected,this);
        });

        public RelayCommand GoRemove => new RelayCommand(obj =>
        {
            State = new RemoveApplicantVM(Selected, this);
        });

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = this;
                    Selected = null;
                });

            }
        }
    }
}
