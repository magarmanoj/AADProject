using AAD.ImmoWin.Business.Classes;
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


        private Woningen _appartement;

        public Woningen Appartement
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
            AppartementEditView = new AppartementEditViewModel();

        }

    }
}
