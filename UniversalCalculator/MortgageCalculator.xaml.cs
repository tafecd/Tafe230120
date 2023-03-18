using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void btnCalculate_Click(object sender, RoutedEventArgs e)
		{
			double principalBorrow, yearlyInterestRate, monthlyInterestRate, monthlyRepayment, doubleInput;
			int years, months, totalMonths, intInput;
			txtblockInputError.Text = "";

			if (txtPrincipalBorrow.Text != "")
			{
				if (Double.TryParse(txtPrincipalBorrow.Text, out doubleInput))
				{
					principalBorrow = doubleInput;
				}
				else
				{
					txtblockInputError.Text = "ERROR: Invalid principal borrow amount.";
					return;
				}
			}
			else
			{
				principalBorrow = 0;
				txtPrincipalBorrow.Text = "0";
			}
			if (principalBorrow < 0)
			{
				txtblockInputError.Text = "ERROR: Principal borrow amount must be greater than or equal to 0.";
				return;
			}

			if (txtYears.Text != "")
			{
				if (int.TryParse(txtYears.Text, out intInput))
				{
					years = intInput;
				}
				else
				{
					txtblockInputError.Text = "ERROR: Invalid number of years.";
					return;
				}
			}
			else
			{
				years = 0;
				txtYears.Text = "0";
			}
			if (years < 0)
			{
				txtblockInputError.Text = "ERROR: Number of years must be greater than or equal to 0.";
				return;
			}

			if (txtMonths.Text != "")
			{
				if (int.TryParse(txtMonths.Text, out intInput))
				{
					months = intInput;
				}
				else
				{
					txtblockInputError.Text = "ERROR: Invalid number of months.";
					return;
				}
			}
			else
			{
				months = 0;
				txtMonths.Text = "0";
			}
			if (months < 0)
			{
				txtblockInputError.Text = "ERROR: Number of months must be greater than or equal to 0.";
				return;
			}

			if (txtYearlyInterestRate.Text != "")
			{
				if (Double.TryParse(txtYearlyInterestRate.Text, out doubleInput))
				{
					yearlyInterestRate = doubleInput;
				}
				else
				{
					txtblockInputError.Text = "ERROR: Invalid yearly interest rate.";
					return;
				}
			}
			else
			{
				yearlyInterestRate = 0;
				txtYearlyInterestRate.Text = "0";
			}
			if (yearlyInterestRate < 0 || yearlyInterestRate > 100)
			{
				txtblockInputError.Text = "ERROR: Yearly interest rate must be between 0 and 100.";
				return;
			}

			totalMonths = (years * 12) + months;
			monthlyInterestRate = yearlyInterestRate / 100 / 12;
			txtMonthlyInterestRate.Text = String.Format("{0:P2}", monthlyInterestRate);

			monthlyRepayment = principalBorrow * (monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), totalMonths)) / (Math.Pow((1 + monthlyInterestRate), totalMonths) - 1);
			txtMonthlyRepayment.Text = String.Format("{0:0.##}", monthlyRepayment);

		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
