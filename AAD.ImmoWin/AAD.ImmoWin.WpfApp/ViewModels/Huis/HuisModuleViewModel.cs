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
    internal class HuisModuleViewModel : BaseViewModel
    {
        private BaseViewModel _huisAddView;
        public BaseViewModel HuisAddView
        {
            get { return _huisAddView; }
            set
            {
                SetProperty(ref _huisAddView, value);
            }
        }

        private BaseViewModel _huisEditView;
        public BaseViewModel HuisEditView
        {
            get { return _huisEditView; }
            set
            {
                SetProperty(ref _huisEditView, value);
            }
        }


        private Woningen _huis;

        public Woningen Huis
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }
        public HuisModuleViewModel()
        {
            // Observable properties
            Huis = KlantenRepository.GetHuizen();

            // Viewmodels
            HuisAddView = new HuisAddViewModel(Huis);
            HuisEditView = new HuisEditViewModel();

        }

    }
}
