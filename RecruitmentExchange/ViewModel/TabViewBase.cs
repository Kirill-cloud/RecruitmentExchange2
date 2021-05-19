using RecruitmentExchange.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    abstract public class TabViewBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected Dictionary<String, List<String>> errors = new Dictionary<string, List<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !errors.ContainsKey(propertyName)) return null;
            return errors[propertyName];
        }
        public bool HasErrors => errors.Count > 0;
        
        protected UserControl state;
        public UserControl State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }


        public virtual RelayCommand GoAdd { get; }
        public virtual RelayCommand Add { get; }
        public virtual RelayCommand GoRemove{ get; }
        public virtual RelayCommand Remove { get; }

    }
}
