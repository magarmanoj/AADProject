using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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



        private List<Klant> _klanten;

        public List<Klant> Klanten
        {
            get { return _klanten; }
            set
            {
                SetProperty(ref _klanten, value);
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


		#endregion

		#endregion

		#region Constructors

		public KlantDetailCommandViewModel()
		{
			// Observable properties
			Title = "Klant detailgegevens";
			IsEnabled = false;
			Status = DetailStatus.Tonen;
            Klanten = KlantenRepository.GetKlanten();

            // Commands
            KlantWijzigingBewarenCommand = new RelayCommand(KlantWijzigingBewarenCommandExecute, KlantWijzigingBewarenCommandCanExecute);
			KlantWijzigingAnnulerenCommand = new RelayCommand(KlantWijzigingAnnulerenCommandExecute);
		}

		#endregion

		#region Methods

		#region Command Methods

		private void KlantWijzigingBewarenCommandExecute()
		{
            try
            {
                KlantenValidatie.ValidateKlant(Klant);
                IsEnabled = false;
                Status = DetailStatus.Bewaren;
                KlantenRepository.UpdateKlantByID(Klant.Id, Klant);
            }
            catch (NaamLeeg_KlantException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
		private Boolean KlantWijzigingBewarenCommandCanExecute()
		{
			return Klant?.Changed ?? false;
		}

		private void KlantWijzigingAnnulerenCommandExecute()
		{
			IsEnabled = false;
			Status = DetailStatus.Annuleren;
		}

		#endregion

		#endregion
	}
}
