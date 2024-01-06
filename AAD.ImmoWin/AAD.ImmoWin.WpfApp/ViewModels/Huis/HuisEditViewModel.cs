using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;

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
            WoningHuizen = KlantenRepository.GetHuizen();

            // Commands
            HuisBewarenCommand = new RelayCommand(HuisBewarenCommandExecute, HuisBewarenCommandCanExecute);
            HuisAnnulerenCommand = new RelayCommand(HuisAnnulerenCommandExecute);
        }

        public void HuisBewarenCommandExecute()
        {
            KlantenRepository.UpdateWoning(Huizen.Id, Huizen);
            WoningHuizen = KlantenRepository.GetHuizen();
            IsEnabled = false;
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return Huizen?.Changed??false;
        }

        private void HuisAnnulerenCommandExecute()
        {
            IsEnabled = false;
        }
    }
}