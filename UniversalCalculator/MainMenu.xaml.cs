using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void CurrencyButton_Copy1_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Currency_Conv));
		}

		private void MortgageButton_Copy_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Mortgage_Calc));
		}

		private void MathsButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}
		
		private async void Trip_Calculator_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new MessageDialog("Trip calculator C# code will be developed later ");
			await dialog.ShowAsync();
			return;
		}
	}
}
