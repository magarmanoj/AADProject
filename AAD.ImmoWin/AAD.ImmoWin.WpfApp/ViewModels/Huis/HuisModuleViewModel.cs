using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.WpfApp.Views;
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


        private List<Huis> _huis;

        public List<Huis> Huis
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
            HuisAddView.PropertyChanged += ViewModel_PropertyChanged;
            HuisEditView = new HuisEditViewModel();
            HuisEditView.PropertyChanged += ViewModel_PropertyChanged;


        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            HuisAddViewModel klvm = (HuisAddViewModel)HuisAddView;
            HuisEditViewModel kdvm = (HuisEditViewModel)HuisEditView;
            if (sender is HuisAddViewModel)
            {
                switch (e.PropertyName)
                {
                    case "GeselecteerdeHuizen":
                        kdvm.Huizen = klvm.GeselecteerdeHuizen;
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
