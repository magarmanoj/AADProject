using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementEditViewModel : BaseViewModel
    {
        public RelayCommand AppartementBewarenCommand { get; set; }
        public RelayCommand AppartementAnnulerenCommand { get; set; }


        private Data.Data.Appartement _appartement;
        public Data.Data.Appartement Appartement
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
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


        private List<Data.Data.Appartement> _appartementen;

        public List<Data.Data.Appartement> Appartementen
        {
            get { return _appartementen; }
            set
            {
                if (_appartementen != value)
                {
                    _appartementen = value;
                    OnPropertyChanged(nameof(Appartementen));
                }
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

        public AppartementEditViewModel()
        {
            Title = "Aanpassen Appartementen";
            IsEnabled = false;
            Status = KlantDetailStatus.Tonen;
            Appartementen = Data.Services.WoningRepository.GetAppartementen();
            Klanten = Data.Services.KlantenRepository.GetKlanten();

            // Commands
            AppartementBewarenCommand = new RelayCommand(AppartementBewarenCommandExecute, AppartementBewarenCommandCanExecute);
            AppartementAnnulerenCommand = new RelayCommand(AppartementAnnulerenCommandExecute);
        }

        public void AppartementBewarenCommandExecute()
        {
            try
            {
                WoningenAppValidatie.ValidateAppartement(Appartement);
                IsEnabled = false;
                Status = KlantDetailStatus.Bewaren;

                Data.Services.WoningRepository.UpdateWoning(Appartement.Id, Appartement);
                if (SelectedType != null)
                {
                    Appartement.Klant = SelectedType;
                    SelectedType.Eigendommen.Add(Appartement);
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
        private Boolean AppartementBewarenCommandCanExecute()
        {
            return true;
        }

        private void AppartementAnnulerenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantDetailStatus.Annuleren;
        }
    }
}