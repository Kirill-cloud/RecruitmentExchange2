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
        public ObservableCollection<User> Users { get; set; } = new();
        public RelayCommandAsync SomeDo
        {
            get
            {
                return new RelayCommandAsync(async (obj) =>
                {
                    LoadingState = "LoadStart";
                    OnPropertyChanged(nameof(LoadingState));
                    await Task.Delay(4000);
                    LoadingState = "Finish";

                    Users = new() { new() {Name = "Петянедурак" } };

                    OnPropertyChanged(nameof(LoadingState));
                    OnPropertyChanged(nameof(Users));
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
