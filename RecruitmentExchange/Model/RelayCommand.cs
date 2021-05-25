using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruitmentExchange.Model
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool IsExecuting { get; set; } = false;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return !IsExecuting && (this.canExecute == null || this.canExecute(parameter));
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        protected async Task ExecuteAsync(object parameter)
        {
            IsExecuting = true;
            try
            {
                this.execute(parameter);
            }
            catch (Exception)
            {
            }
            IsExecuting = false;
        }
    }
}
