using BirthdayDateProject01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateProject01.Tools;
using System.Windows;
using DateProject01.Tools.Managers;
using System.Threading;
using System.Windows.Controls;

namespace DateProject01.ViewModels.UserBirthday
{
    class UserViewModel : BaseViewModel
    {
        #region Fields
        private User user;

        private string _age;
        private string _greeting;
        private string _zodiak;
        private string _chineseZodiak;
        #endregion

        #region Messages
        private string ERROR_MESSAGE = "There was a mistake. You have not yet been born or your age is above 135";
        private string CONGRATULATIONS = "\nHappy Birthday!";
        #endregion

        public UserViewModel()
        {
            user = new User();
        }

        #region Commands
        private RelayCommand<object> countCommand;
        public RelayCommand<object> CountCommand
        {
            get
            {
                return countCommand ??
                  (countCommand = new RelayCommand<object>(async obj =>
                  {
                      Age = "";
                      Greeting = "";
                      Zodiak = "";
                      ChineseZodiak = "";

                      LoaderManager.Instance.ShowLoader();
                      await Task.Run(() => Thread.Sleep(1000));
                      LoaderManager.Instance.HideLoader();
                     

                      int inputAge = countAge();
                      if (inputAge <= 0 || inputAge >= 135)
                      {
                          MessageBox.Show(ERROR_MESSAGE);
                      }
                      else 
                      {
                          if (Birthday.Day == DateTime.Today.Day)
                              Greeting = CONGRATULATIONS;

                          Age = "Your age: \n" + countAge();
                          Zodiak = "Your zodiak is " + discoverZodiac();
                          ChineseZodiak = "Your Chineese zodiak is " + countChineeseZodiak();
                      }

                   }));
            }
            }
        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return user.Birthday; }
            set {user.Birthday = value; OnPropertyChanged(); }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public string Greeting
        {
            get { return _greeting; }
            set { _greeting = value; OnPropertyChanged(); }
        }

        public string Zodiak
        {
            get { return _zodiak; }
            set { _zodiak = value; OnPropertyChanged(); }
        }

        public string ChineseZodiak
        {
            get { return _chineseZodiak; }
            set { _chineseZodiak = value; OnPropertyChanged(); }
        }
        #endregion


        #region Functionality
        private int countAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday > today.AddYears(-age)) age--;

            return age;
        }

        private string discoverZodiac()
        {
            int moth = Birthday.Month;
            int day = Birthday.Day;
            switch (moth)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }

        private string countChineeseZodiak()
        {
            System.Globalization.EastAsianLunisolarCalendar cc = new System.Globalization.ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(Birthday);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = new string[] { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return years[terrestrialBranch - 1];
        }
        #endregion

    }
}
