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
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    public class CompanyVM : INotifyPropertyChanged
    {
        public CompanyVM()
        {
            state = new IdleCompanyView() { DataContext = this };
        }

        public string Name { get; set; }
        public string Focus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Company Selected { get; set; }
        UserControl state;
        public UserControl State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public List<Company> Companies { get { 
                return DBMethods.GetAllCompanies();
            } }
        public RelayCommand RemoveCompany
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    await DBMethods.RemoveCompany(Selected);
                    OnPropertyChanged("Companies");
                });
            }
        }
        public RelayCommand AddCompany
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new AddCompany() {DataContext = this };
                });
            }
        }
        public RelayCommand Add
        {
            get
            {
                return new RelayCommand(obj => {

                    DBMethods.AddCompany(new Company() {
                        Name = Name,
                        Address =Address,
                        FocusedOn =Focus,
                        Phone =Phone,

                    });
                    State = new IdleCompanyView() { DataContext = this };
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
