﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyIMS.ViewModels
{
    class ViewModelLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;
        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                if (_mainWindowViewModel == null)
                {
                    _mainWindowViewModel = new MainWindowViewModel();
                }
                return _mainWindowViewModel;
            }
        }
        private static LogInWindowViewModel _logInWindowViewModel;
        public static LogInWindowViewModel LogInWindowViewModel
        {
            get
            {
                if (_logInWindowViewModel == null)
                {
                    _logInWindowViewModel = new LogInWindowViewModel();
                }
                return _logInWindowViewModel;
            }
        }
    }
}
