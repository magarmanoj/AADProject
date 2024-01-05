using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
	public class KlantDetailCommandViewModel : BaseViewModel
	{
		#region Properties

		#region Command properties

		public RelayCommand KlantWijzigingBewarenCommand { get; }
		public RelayCommand KlantWijzigingAnnulerenCommand { get; }

		#endregion

		#region Observable properties

		private Klant _klant;
		public Klant Klant
		{
			get { return _klant; }
			set
			{
				SetProperty(ref _klant, value);
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


		#endregion

		#endregion

		#region Constructors

		public KlantDetailCommandViewModel()
		{
			// Observable properties
			Title = "Klant detailgegevens";
			IsEnabled = false;
			Status = KlantDetailStatus.Tonen;

			// Commands
			KlantWijzigingBewarenCommand = new RelayCommand(KlantWijzigingBewarenCommandExecute, KlantWijzigingBewarenCommandCanExecute);
			KlantWijzigingAnnulerenCommand = new RelayCommand(KlantWijzigingAnnulerenCommandExecute);
		}

		#endregion

		#region Methods

		#region Command Methods

		private void KlantWijzigingBewarenCommandExecute()
		{
			KlantenRepository.UpdateKlant(Klant);
            IsEnabled = false;
            Status = KlantDetailStatus.Bewaren;
        }
		private Boolean KlantWijzigingBewarenCommandCanExecute()
		{
			return Klant?.Changed ?? false;
		}

		private void KlantWijzigingAnnulerenCommandExecute()
		{
			IsEnabled = false;
			Status = KlantDetailStatus.Annuleren;
		}

		#endregion

		#endregion
	}
}
