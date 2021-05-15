using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecruitmentExchange.ViewModel
{
    public class EditCompanyVM
    {
        public string Name { get; set; }
        public string Focus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        readonly Window window;

        public EditCompanyVM(Window window) 
        {
            this.window = window;
        }

        public RelayCommand AddCompany
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var x = new Company()
                    {
                        Name = Name,
                        FocusedOn = Focus,
                        Address = Address,
                        Phone = Phone
                    };

                    DBMethods.AddCompany(x);
                    window.Close();
                });
            }
        }
    }
}
