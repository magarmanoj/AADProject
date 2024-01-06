using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        private List<Appartement> _appartement;

        public List<Appartement> Appartement
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
            Appartement = KlantenRepository.GetAppartementen();

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
                        if (klvm.Status == LijstStatus.Wijzigen)
                        {
                            kdvm.Status = DetailStatus.Wijzigen;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (sender is AppartementEditViewModel)
            {
                switch (e.PropertyName)
                {
                    case "Appartement":
                        klvm.Appartementen = kdvm.Appartementen;
                        break;
                }
            }
            else
            {
                switch (e.PropertyName)
                {
                    case "Status":
                        if (kdvm.Status == DetailStatus.Annuleren)
                        {
                            klvm.Status = LijstStatus.Tonen;
                        }
                        else if (kdvm.Status == DetailStatus.Bewaren)
                        {
                            klvm.Status = LijstStatus.Tonen;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
