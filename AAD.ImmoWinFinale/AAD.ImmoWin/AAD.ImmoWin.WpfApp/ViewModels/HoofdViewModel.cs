﻿using AAD.ImmoWin.Data.Data;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class HoofdViewModel : BaseViewModel
    {
        #region Properties

        #region Command properties

        public RelayCommand ExitCommand { get; }
        public RelayCommand KlantenModuleCommand { get; }
        public RelayCommand AppartementModuleCommand { get; }
        public RelayCommand HuisModuleCommand { get; }
        public RelayCommand LegeDataCommand { get; private set; }
        public RelayCommand InitieleDataCommand { get; private set; }
        public RelayCommand HuidigeDataCommand { get; private set; }

        #endregion

        #region Observable properties

        private BaseViewModel _huidigeModuleViewModel;

        public BaseViewModel HuidigeModuleViewModel
        {
            get { return _huidigeModuleViewModel; }
            set
            {
                SetProperty(ref _huidigeModuleViewModel, value);
            }
        }
        #endregion

        #endregion

        #region Constructors

        public HoofdViewModel()
        {
            // Observable properties
            Title = "ImmoWin - MVVM - View & ViewModel";

            // Commands
            ExitCommand = new RelayCommand(ExitCommandExecute);
            KlantenModuleCommand = new RelayCommand(KlantenModuleCommandExecute, KlantenModuleCommandCanExecute);
            AppartementModuleCommand = new RelayCommand(AppartementModuleCommandExecute, AppartementModuleCommandCanExecute);
            HuisModuleCommand = new RelayCommand(HuisModuleCommandExecute, HuisModuleCommandCanExecute);
            LegeDataCommand = new RelayCommand(LegeDataCommandExecute);
            InitieleDataCommand = new RelayCommand(InitieleDataCommandExecute);
            HuidigeDataCommand = new RelayCommand(HuidigeDataCommandExecute);
        }

        #endregion

        #region Methods

        private void LegeDataCommandExecute()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                ConnectionRepository.ClearDataBase(context);
            }
        }

        private void InitieleDataCommandExecute()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                ConnectionRepository.Seed(context);
            }
        }

        private void HuidigeDataCommandExecute()
        {
        }
        #region Command methods

        private void ExitCommandExecute()
        {
            Application.Current.Shutdown();
        }

        private void KlantenModuleCommandExecute()
        {
            HuidigeModuleViewModel = new KlantenModuleViewModel();
        }
        private Boolean KlantenModuleCommandCanExecute()
        {
            return !(HuidigeModuleViewModel is KlantenModuleViewModel);
        }

        private void AppartementModuleCommandExecute()
        {
            HuidigeModuleViewModel = new AppartementModuleViewModel();
        }

        private Boolean AppartementModuleCommandCanExecute()
        {
            return !(HuidigeModuleViewModel is AppartementModuleViewModel);
        }


        private void HuisModuleCommandExecute()
        {
            HuidigeModuleViewModel = new HuisModuleViewModel();
        }

        private Boolean HuisModuleCommandCanExecute()
        {
            return !(HuidigeModuleViewModel is HuisModuleViewModel);
        }



        #endregion

        #endregion
    }
}
