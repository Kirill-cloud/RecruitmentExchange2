using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        List<Company> companies = new();
        public List<Company> Companies
        {
            get { companies = DBMethods.GetAllCompanies(); return companies; }
            set
            {
                companies = value;
                OnPropertyChanged("Companies");
            }
        }

        public List<Role> Roles { get { return DBMethods.GetAllRoles(); } }
        List<Vacancy> vacancies;
        public List<Vacancy> Vacancies
        {
            get
            {
                vacancies = DBMethods.GetAllVacancies();
                return vacancies;
            }
        }

        UserControl aplicantView = new ApplicantControl();
        public UserControl AplicantView { get { return aplicantView; } }

        public RelayCommand RemoveCompany
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    // OpenWindow(new AddNewCompanyWindow());
                    await DBMethods.RemoveCompany(DBMethods.GetCompanyById((obj as Company).Id));
                    OnPropertyChanged("Companies");
                }
                );
            }
        }

        public RelayCommand AddAplicant
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        aplicantView = new AddAplicantControl();
                        OnPropertyChanged("AplicantView");
                    });
            }
        }
        public RelayCommand AplicantAdded
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        aplicantView = new ApplicantControl();
                        OnPropertyChanged("AplicantView");
                    });
            }
        }
        public RelayCommand AddVacancyWindow
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    OpenWindow(new AddNewVacancyWindow());

                    OnPropertyChanged("Vacancies");
                }
                );
            }
        }

        public RelayCommand AddCompanyWindow
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    OpenWindow(new AddNewCompanyWindow());

                    OnPropertyChanged("Companies");
                }
                );
            }
        }



        private void OpenWindow(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
