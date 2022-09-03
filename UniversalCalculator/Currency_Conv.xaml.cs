using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Currency_Conv : Page
	{



		public Currency_Conv()
		{
			this.InitializeComponent();
		}
		double Amount = 0;
		double ConversionRate;
		double Result;
		string Symbol;
		public async void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			string SourceCurrency;
			string DestinationCurrency;
			


			//Get text from Combo Boxes
			var ComboBoxItem = FromComboBox.Items[FromComboBox.SelectedIndex] as ComboBoxItem;
			SourceCurrency = ComboBoxItem.Content.ToString();
			var ComboBoxItem1 = ToComboBox.Items[ToComboBox.SelectedIndex] as ComboBoxItem;
			DestinationCurrency = ComboBoxItem1.Content.ToString();

			//Switch Case statements to determine conversion rate
			try
			{
				Amount = double.Parse(AmountTextBox.Text);
			}
			catch (FormatException exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				AmountTextBox.Focus(FocusState.Programmatic);
				AmountTextBox.SelectAll();
				return;
			}
			catch (Exception exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				AmountTextBox.Focus(FocusState.Programmatic);
				AmountTextBox.SelectAll();
				return;
			}

			double GetConvRate(string Source, string dest)
			{
				switch (Source)
				{
					case "US Dollar":
						switch (dest)
						{
							case "Euro":
								ConversionRate = 0.85189982;
								Symbol = "\u20AC";
								break;
							case "British Pound":
								ConversionRate = 0.72872436;
								Symbol = "\u00A3";
								break;
							case "Indian Rupee":
								ConversionRate = 74.257327;
								Symbol = "\u20B9";
								break;
							case "US Dollar":
								ConversionRate = 1;
								Symbol = "$";
								break;

						}
						break;
					case "Euro":
						switch (dest)
						{
							case "US Dollar":
								ConversionRate = 1.1739732;
								Symbol = "$";
								break;
							case "British Pound":
								ConversionRate = 0.8556672;
								Symbol = "\u00A3";
								break;
							case "Indian Rupee":
								ConversionRate = 87.00755;
								Symbol = "\u20B9";
								break;
							case "Euro":
								ConversionRate = 1;
								Symbol = "\u20AC";
								break;
						}
						break;
					case "British Pound":
						switch (dest)
						{
							case "US Dollar":
								ConversionRate = 1.371907;
								Symbol = "$";
								break;
							case "Euro":
								ConversionRate = 1.1686692;
								Symbol = "\u20AC";
								break;
							case "Indian Rupee":
								ConversionRate = 101.68635;
								Symbol = "\u20B9";
								break;
							case "British Pound":
								ConversionRate = 1;
								Symbol = "\u00A3";
								break;

						}
						break;
					case "Indian Rupee":
						switch (dest)
						{
							case "US Dollar":
								ConversionRate = 0.011492628;
								Symbol = "$";
								break;
							case "Euro":
								ConversionRate = 0.013492774;
								Symbol = "\u20AC";
								break;
							case "British Pound":
								ConversionRate = 0.0098339397;
								Symbol = "\u00A3";
								break;
							case "Indian Rupee":
								ConversionRate = 1;
								Symbol = "\u20B9";
								break;
						}
						break;

				}
				return ConversionRate;
			}
			//if source and destination currency are the same Conversion Rate is 1
			if (SourceCurrency == DestinationCurrency)
			{
				ConversionRate = 1.0;
			}
			//Call the currency converter method passining in the amnount and conversion rate
			Result = CurrencyConvert(Amount, GetConvRate(SourceCurrency, DestinationCurrency));
			//Populate the textblocks
			SourceTextBlock.Text = Amount.ToString() + " " + SourceCurrency + "s = ";
			ResultTextBlock.Text = Symbol + Result.ToString() + " " + DestinationCurrency + "s";
			FromResultTextBlock.Text = "1 " + SourceCurrency + " =" + (CurrencyConvert(1, ConversionRate)) + " " + DestinationCurrency+"s";
			ToResultTextBlock.Text = "1 " + DestinationCurrency + " =" + CurrencyConvert(1, GetConvRate(DestinationCurrency, SourceCurrency)) + " " + SourceCurrency + "s";
		}
		//Currency convert method
		static double CurrencyConvert(double amt, double conv)
		{
			double result = amt * conv;
			return result;

		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}


}





