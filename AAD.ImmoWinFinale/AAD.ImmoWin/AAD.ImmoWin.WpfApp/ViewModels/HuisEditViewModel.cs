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

        private Data.Data.Huis _huis;

        public Data.Data.Huis Huizen
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }

        private List<Data.Data.Huis> _woningHuizen;

        public List<Data.Data.Huis> WoningHuizen
        {
            get { return _woningHuizen; }
            set
            {
                SetProperty(ref _woningHuizen, value);
            }
        }

        private List<Data.Data.Klant> _klanten;
        public List<Data.Data.Klant> Klanten
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

        private Data.Data.Klant _selectedType;
        public Data.Data.Klant SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private KlantDetailStatus _status;

        public KlantDetailStatus Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    switch (Status)
                    {
                        case KlantDetailStatus.Tonen:
                            break;
                        case KlantDetailStatus.Wijzigen:
                            IsEnabled = true;
                            break;
                        case KlantDetailStatus.Bewaren:
                            break;
                        case KlantDetailStatus.Annuleren:
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
            Status = KlantDetailStatus.Tonen;
            WoningHuizen = Data.Services.WoningRepository.GetHuizen();
            Klanten = Data.Services.KlantenRepository.GetKlanten();

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
                Status = KlantDetailStatus.Bewaren;

                Data.Services.WoningRepository.UpdateWoning(Huizen.Id, Huizen);
                if (SelectedType != null)
                {
                    Huizen.Klant = SelectedType;
                    SelectedType.Eigendommen.Add(Huizen);
                    Data.Services.KlantenRepository.UpdateKlantByID(SelectedType.Id, SelectedType);
                }
            }
            catch (WaardeTeKlein_WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (StraatLeeg_AdresException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NummerTeKlein_AdresException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PostnummerTeKlein_AdresException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (GemeenteLeeg_AdresException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BouwdatumTeGroot_WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return true;
        }

        private void HuisAnnulerenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantDetailStatus.Annuleren;
        }
    }
}