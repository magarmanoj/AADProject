using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class HuisEditViewModel : BaseViewModel
    {
        public RelayCommand HuisBewarenCommand { get; set; }
        public RelayCommand HuisAnnulerenCommand { get; set; }

        private Huis _huis;

        public Huis Huizen
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }

        private List<Huis> _woningHuizen;

        public List<Huis> WoningHuizen
        {
            get { return _woningHuizen; }
            set
            {
                SetProperty(ref _woningHuizen, value);
            }
        }

        private List<Klant> _klanten;
        public List<Klant> Klanten
        {
            get
            {
                return _klanten;
            }
            set
            {
                SetProperty(ref _klanten, value);
            }
        }

        private Klant _selectedType;
        public Klant SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private DetailStatus _status;

        public DetailStatus Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    switch (Status)
                    {
                        case DetailStatus.Tonen:
                            break;
                        case DetailStatus.Wijzigen:
                            IsEnabled = true;
                            break;
                        case DetailStatus.Bewaren:
                            break;
                        case DetailStatus.Annuleren:
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        public HuisEditViewModel()
        {
            Title = "Aanpassen Huizen";
            IsEnabled = false;
            Status = DetailStatus.Tonen;
            WoningHuizen = KlantenRepository.GetHuizen();
            Klanten = KlantenRepository.GetKlanten();

            // Commands
            HuisBewarenCommand = new RelayCommand(HuisBewarenCommandExecute, HuisBewarenCommandCanExecute);
            HuisAnnulerenCommand = new RelayCommand(HuisAnnulerenCommandExecute);
        }

        public void HuisBewarenCommandExecute()
        {
            try
            {
                WoningenHuizenValidatie.ValidateHuizen(Huizen);
                IsEnabled = false;
                Status = DetailStatus.Bewaren;

                KlantenRepository.UpdateWoning(Huizen.Id, Huizen);
                if (SelectedType != null)
                {
                    Huizen.Klant = SelectedType;
                    SelectedType.Eigendommen.Add(Huizen);
                    KlantenRepository.UpdateKlantByID(SelectedType.Id, SelectedType);

                }
                WoningHuizen = KlantenRepository.GetHuizen();
            }
            catch (WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return Huizen?.Changed ?? false;
        }

        private void HuisAnnulerenCommandExecute()
        {
            IsEnabled = false;
            Status = DetailStatus.Annuleren;
        }
    }
}