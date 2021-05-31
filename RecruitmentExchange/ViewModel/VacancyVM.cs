using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View.Vacancy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    public class VacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Вакансии";


        public VacancyVM()
        {
            Cancel.Execute(null);
        }
        
        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (State is IdleVacancyVM)
                    {
                        new EditVacancyVM(null, this);
                    }
                });
            }
        }
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (State is IdleVacancyVM)
                    {
                        IdleVacancyVM vM = (IdleVacancyVM)State;
                        if (vM.Selected != null)
                        {
                            new EditVacancyVM(vM.Selected, this);
                        }
                    }
                });
            }
        }
        public RelayCommand GoRemove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (State is IdleVacancyVM)
                    {
                        IdleVacancyVM vM = (IdleVacancyVM)State;
                        if (vM.Selected != null)
                        {
                            new RemoveVacancyVM(vM.Selected, this);
                        }
                    }
                });
            }
        }
        public bool IsLoading { get; private set; }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    IsLoading = true;
                    State = new LoadingVM();

                    DBMethods db = new();
                    State = new IdleVacancyVM(await db.GetAllVacancies());

                    IsLoading = false;
                });

            }
        }

    }
}
