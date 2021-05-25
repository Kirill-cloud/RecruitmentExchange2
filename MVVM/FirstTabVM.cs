using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class FirstTabVM : VMBase
    {
        public string LoadingState { get; set; } = "Nothing";
        public ObservableCollection<Company> Users { get; set; } = new();

        public FirstTabVM()
        {
            SomeDo.Execute(null);
        }
        public RelayCommandAsync SomeDo
        {
            get
            {
                return new RelayCommandAsync(async (obj) =>
                {
                    LoadingState = "LoadStart";
                    OnPropertyChanged(nameof(LoadingState));
                    //await Task.Delay(4000);
                    LoadingState = "Finish";

                    DBMethods dB = new();
                    Users = new ObservableCollection<Company>(await dB.GetAllCompanies());

                    OnPropertyChanged(nameof(LoadingState));
                    OnPropertyChanged(nameof(Users));
                });
            }
        }
        public RelayCommandAsync SomeAdd
        {
            get
            {
                return new RelayCommandAsync(async (obj) =>
                {
                    LoadingState = "LoadStart";
                    OnPropertyChanged(nameof(LoadingState));
                    //await Task.Delay(4000);

                    DBMethods dB = new();
                    await dB.AddCompany(new Company() { Name ="RLLY NIGGA?"  });

                    SomeDo.Execute(null);
                    LoadingState = "Finish";

                });
            }
        }
        public class User
        {
            public string Name { get; set; }
            public int Salary { get; set; }
        }
    }
}
