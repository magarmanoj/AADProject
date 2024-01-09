using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Enumerations;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;


namespace AAD.ImmoWin.ConsoleApp
{
	internal class Program
	{
		static public Klanten Klanten { get; set; } = new Klanten();

		static private void VulKlanten()
		{
			IKlant klant;
			IWoning woning;

			try
			{
                klant = new Klant("Theo", "Flitser");
                Klanten.Add(klant);

                klant = new Klant("Bert", "Bibber");
                woning = new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 0);
                klant.Eigendommen.Add(woning);
                Klanten.Add(klant);

                klant = new Klant("Junior", "Warwinkel");
                woning = new Appartement(0, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0);
                klant.Eigendommen.Add(woning);
                Klanten.Add(klant);

                klant = new Klant("Piet", "Pienter");
                klant.Eigendommen.Add(new Appartement(1, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Rijhuis, new Adres("Stormstraat", 3, 1000, "Brussel"), DateTime.Now, 0));
                Klanten.Add(klant);

                klant = new Klant("Hilarius", "Warwinkel");
                klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Vrijstaand, new Adres("Stormstraat", 5, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Appartement(3, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Appartement(2, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Appartement(5, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Huis(Business.Enumerations.Huistype.Tweegevel, new Adres("Stormstraat", 1, 1000, "Brussel"), DateTime.Now, 0));
                klant.Eigendommen.Add(new Appartement(4, new Adres("Stormstraat", 2, 1000, "Brussel"), DateTime.Now, 0));
                Klanten.Add(klant);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			Console.WriteLine("\nKlanten gevuld.");
		}

		static void ToonKlanten()
		{
			Console.WriteLine("\nKlanten:");

			List<IKlant> klantenList = Klanten.ToList<IKlant>();
			klantenList.Sort();

			foreach (IKlant k in klantenList)
			{
				Console.WriteLine($"{k}");
				List<IWoning> eigendommenList = k.Eigendommen.ToList<IWoning>();
				eigendommenList.Sort();
				foreach (IWoning w in eigendommenList)
					Console.WriteLine($"\t{w}");
			}
			Console.WriteLine();
		}


		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Default;

			VulKlanten();
			//ToonKlanten();
			//TestAdresExceptions();
			TestPropertyChanged();


			Console.ReadKey();
		}

		static void TestAdresExceptions()
		{
			Console.WriteLine("\nTest Adres Exceptions");
			int deel = 1;
			Adres adres = null;
			while (deel != 0)
			{
				try
				{
					switch (deel)
					{
						case 1:
							adres = new Adres(null, 0, 0, null);
							break;
						case 2:
							adres = new Adres("Stormstraat", 0, 0, null);
							break;
						case 3:
							adres = new Adres("Stormstraat", 1, 0, null);
							break;
						case 4:
							adres = new Adres("Stormstraat", 1, 1000, null);
							break;
						case 5:
							adres = new Adres("Stormstraat", 1, 1000, "Brussel");
							break;
						default:
							break;
					}
					deel = 0;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"{deel}) {ex.GetType().Name}: {ex.Message}");
					++deel;
				}
			}
			Console.WriteLine($"adres: {adres}");
		}

		static void TestPropertyChanged()
		{
			Console.WriteLine($"{Klanten[4].Eigendommen.Count}");
			Klanten[4].PropertyChanged += Program_PropertyChanged;
			Klanten[4].Voornaam = "test";
			Klanten[4].Eigendommen[0].Waarde = 1234567;


			
		}

		private static void Program_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Console.WriteLine($"Klant {e.PropertyName} gewijzigd.");
		}
	}
}
