using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;
using System.Runtime.CompilerServices;
using DateProject01.Tools;

namespace BirthdayDateProject01.Models
{
    internal class User : BaseViewModel
    {
        private DateTime _birthday;

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; OnPropertyChanged("Birthday"); }
        }

    }
}
