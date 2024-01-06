using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
	internal class KlantenModuleViewModel : BaseViewModel
	{
		#region Properties

		#region Observable properties

		private BaseViewModel _huidigeKlantenLijstViewModel;
		public BaseViewModel HuidigeKlantenLijstViewModel
		{
			get { return _huidigeKlantenLijstViewModel; }
			set
			{
				SetProperty(ref _huidigeKlantenLijstViewModel, value);
			}
		}

		private BaseViewModel _huidigeKlantDetailViewModel;
		public BaseViewModel HuidigeKlantDetailViewModel
		{
			get { return _huidigeKlantDetailViewModel; }
			set
			{
				SetProperty(ref _huidigeKlantDetailViewModel, value);
			}
		}

        private List<Klant> _klanten;

        public List<Klant> Klanten
        {
            get { return _klanten; }
            set
            {
                SetProperty(ref _klanten, value);
            }
        }


        #endregion

        #endregion

        #region Constructors

        public KlantenModuleViewModel()
		{

			// Observable properties
			Klanten = KlantenRepository.GetKlanten();

            // Viewmodels
            HuidigeKlantenLijstViewModel = new KlantenLijstViewModel(Klanten);
			HuidigeKlantenLijstViewModel.PropertyChanged += ViewModel_PropertyChanged;
			HuidigeKlantDetailViewModel = new KlantDetailCommandViewModel();
			HuidigeKlantDetailViewModel.PropertyChanged += ViewModel_PropertyChanged;
		}

		private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			KlantenLijstViewModel klvm = (KlantenLijstViewModel)HuidigeKlantenLijstViewModel;
			KlantDetailCommandViewModel kdvm = (KlantDetailCommandViewModel)HuidigeKlantDetailViewModel;
			if (sender is KlantenLijstViewModel)
			{
				switch (e.PropertyName)
				{
					case "GeselecteerdeKlant":
						kdvm.Klant = klvm.GeselecteerdeKlant;
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

		#endregion

		#region Methods

		#endregion
	}
}
