using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Mortgage_Calc : Page
	{
		public Mortgage_Calc()
		{
			this.InitializeComponent();
		}

		private async void btnCalc_Click(object sender, RoutedEventArgs e)
		{
			double princAmount = 0;
			double monthlyInt = 0;
			double numMonths = 0;
			double repayAmount = 0;
			double monthlyIntCalc = 0;
			double numYears = 0;
			double yearlyInt = 0;
			double yearlyIntPerc = 0;


			//try catch for Principal Amount
			try
			{
				princAmount = Convert.ToDouble(txt_princBorrow.Text);
			}
			catch (FormatException exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				txt_princBorrow.Focus(FocusState.Programmatic);
				txt_princBorrow.SelectAll();
				return;
			}

			//try catch for Number of Years
			try
			{
				numYears = Convert.ToDouble(txt_years.Text);
			}
			catch (FormatException exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				txt_years.Focus(FocusState.Programmatic);
				txt_years.SelectAll();
				return;
			}

			//try catch for Number of Months
			try
			{
				numMonths = Convert.ToDouble(txt_months.Text);
			}
			catch (FormatException exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				txt_months.Focus(FocusState.Programmatic);
				txt_months.SelectAll();
				return;
			}

			try
			{
				yearlyInt = Convert.ToDouble(txt_intrestRate.Text);
			}
			catch (FormatException exception)
			{
				var dialog = new MessageDialog("incorrect number format " + exception.Message);
				await dialog.ShowAsync();
				txt_intrestRate.Focus(FocusState.Programmatic);
				txt_intrestRate.SelectAll();
				return;
			}

			numMonths = numMonths + (numYears * 12);
			yearlyIntPerc = yearlyInt / 100;

			//calculate monthly intrest rate
			monthlyInt = yearlyIntPerc / 12;
			monthlyIntCalc = 1 + monthlyInt;
			txt_monthRate.Text = Math.Round(monthlyInt,5).ToString() + "%";

			double power = Math.Pow(monthlyIntCalc, numMonths);
			
		//Calculate repayment
			repayAmount = (princAmount * (monthlyInt * power))/(power - 1);
			txt_monthRepayment.Text = Math.Round(repayAmount,2).ToString();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
			
		}

	}
}
