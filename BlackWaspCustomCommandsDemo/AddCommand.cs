using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlackWaspCustomCommandsDemo
{
    class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var nameList = parameter as NameList;
            return nameList != null
                && !string.IsNullOrWhiteSpace(nameList.FirstName)
                && !string.IsNullOrWhiteSpace(nameList.LastName);
        }

        public void Execute(object parameter)
        {
            var nameList = parameter as NameList;
            var newName = string.Format("{0} {1}", nameList.FirstName, nameList.LastName);
            nameList.Names.Add(newName);
            nameList.FirstName = nameList.LastName = "";
        }
    }
}
