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
        public abstract string TabName { get; set; }




        // Observable
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public Dictionary<String, List<String>> Errors
        {
            get; 
            set;
        } = new Dictionary<string, List<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !Errors.ContainsKey(propertyName)) return null;
            return Errors[propertyName];
        }
        public bool HasErrors => Errors.Count > 0;
    }
}
