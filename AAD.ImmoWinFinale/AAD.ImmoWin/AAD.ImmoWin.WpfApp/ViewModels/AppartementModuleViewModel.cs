using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.ViewModels;
using System.Collections.Generic;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    internal class AppartementModuleViewModel : BaseViewModel
    {
        private BaseViewModel _appartementAddView;
        public BaseViewModel AppartementAddView
        {
            get { return _appartementAddView; }
            set
            {
                SetProperty(ref _appartementAddView, value);
            }
        }

        private BaseViewModel _appartementEditView;
        public BaseViewModel AppartementEditView
        {
            get { return _appartementEditView; }
            set
            {
                SetProperty(ref _appartementEditView, value);
            }
        }


        private List<Data.Data.Appartement> _appartement;

        public List<Data.Data.Appartement> Appartement
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }


        public AppartementModuleViewModel()
        {
            // Observable properties
            Appartement = Data.Services.WoningRepository.GetAppartementen();

            // Viewmodels
            AppartementAddView = new AppartementAddViewModel(Appartement);
            AppartementAddView.PropertyChanged += ViewModel_PropertyChanged;

            AppartementEditView = new AppartementEditViewModel();
            AppartementEditView.PropertyChanged += ViewModel_PropertyChanged;

        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AppartementAddViewModel klvm = (AppartementAddViewModel)AppartementAddView;
            AppartementEditViewModel kdvm = (AppartementEditViewModel)AppartementEditView;
            if (sender is AppartementAddViewModel)
            {
                switch (e.PropertyName)
                {
                    case "GeselecteerdeAppartement":
                        kdvm.Appartement = klvm.GeselecteerdeAppartement;
                        break;
                    case "Status":
                        if (klvm.Status == KlantLijstStatus.Wijzigen)
                        {
                            kdvm.Status = KlantDetailStatus.Wijzigen;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (e.PropertyName)
                {
                    case "Status":
                        if (kdvm.Status == KlantDetailStatus.Annuleren)
                        {
                            klvm.Status = KlantLijstStatus.Tonen;
                        }
                        else if (kdvm.Status == KlantDetailStatus.Bewaren)
                        {
                            klvm.Status = KlantLijstStatus.Tonen;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
