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
    abstract public class TabViewBase : INotifyPropertyChanged
    {
        public abstract string TabName { get; set; }

        protected TabContentBase state;
        public TabContentBase State
        {
            get
            {
                return state;
            }
            set
            {
                state = value; 
                OnPropertyChanged();
            }
        }

        // Observable
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
