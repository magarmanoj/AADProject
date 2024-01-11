using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Data.Services;
using Odisee.Common.ViewModels;
using System.Collections.Generic;

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

		private List<Data.Data.Klant> _klanten;

		public List<Data.Data.Klant> Klanten
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

        #endregion

        #region Methods

        #endregion
    }
}
