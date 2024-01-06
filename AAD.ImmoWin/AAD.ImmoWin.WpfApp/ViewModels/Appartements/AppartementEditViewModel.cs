using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementEditViewModel : BaseViewModel
    {
        public RelayCommand AppartementBewarenCommand { get; set; }
        public RelayCommand AppartementAnnulerenCommand { get; set; }


        private Appartement _appartement;
        public Appartement Appartement
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }


        private List<Appartement> _appartementen;

        public List<Appartement> Appartementen
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

        public AppartementEditViewModel()
        {
            Title = "Aanpassen Appartementen";
            IsEnabled = false;
            Appartementen = KlantenRepository.GetAppartementen();
            // Commands
            AppartementBewarenCommand = new RelayCommand(AppartementBewarenCommandExecute, AppartementBewarenCommandCanExecute);
            AppartementAnnulerenCommand = new RelayCommand(AppartementAnnulerenCommandExecute);
        }

        public void AppartementBewarenCommandExecute()
        {
            KlantenRepository.UpdateWoning(Appartement.Id, Appartement);
            Appartementen = KlantenRepository.GetAppartementen();
            IsEnabled = false;
        }
        private Boolean AppartementBewarenCommandCanExecute()
        {
            return Appartement?.Changed??false;
        }

        private void AppartementAnnulerenCommandExecute()
        {
            IsEnabled = false;
        }
    }
}