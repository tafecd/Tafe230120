using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConversionCalculator : Page
	{
		// Currency symbols varialbles
		private string us = "$";
		private string euro = "€";
		private string pound = "£";
		private string rupee = "₹";

		// Currency pair values variables
		private double us_us = 1.0;
		private double us_euro = 0.85189982;
		private double us_pound = 0.72872436;
		private double us_rupee = 74.257327;
		private double euro_euro = 1.0;
		private double euro_us = 1.1739732;
		private double euro_pound = 0.8556672;
		private double euro_rupee = 87.00755;
		private double pound_pound = 1.0;
		private double pound_us = 1.371907;
		private double pound_euro = 1.1686692;
		private double pound_rupee = 101.68635;
		private double rupee_rupee = 1.0;
		private double rupee_us = 0.011492628;
		private double rupee_euro = 0.013492774;
		private double rupee_pound = 0.0098339397;

		// Get Current Options
		private string curAmt = null;
		private double dblFromAmt = 0.0;
		private string curFrom = null;
		private string curTo = null;
		private double dblToAmt = 0.0;

		// boolean check error variable
		private bool bError = false;

		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			// Close the current currency conversion calculator page
			Frame.GoBack();
		}


		private void updateLblAmountFrom()
		{
			// Clear all labels
			lblAmountFrom.Text = "";
			lblConvertedTo.Text = "";
			lblOneFromEqualTo.Text = "";
			lblOneToEqualFrom.Text = "";

			if (curAmt != null)
			{
				if (curFrom != null)
				{
					if (curTo != null)
					{
						if (dblFromAmt > 1)
						{
							lblAmountFrom.Text = curAmt + " " + curFrom + "s to " + curTo + "s = ";
						} else
						{
							lblAmountFrom.Text = curAmt + " " + curFrom + " to " + curTo + " = ";
						}						
					} else
					{
						if (dblFromAmt > 1)
						{
							lblAmountFrom.Text = curAmt + " " + curFrom + "s to ";
						}
						else
						{
							lblAmountFrom.Text = curAmt + " " + curFrom + " to ";
						}
					}
				} else
				{
					lblAmountFrom.Text = curAmt;
				}
			}
		}

		private void BtnConversion_Click(object sender, RoutedEventArgs e)
		{

			// Check amount is not empty
			if (string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(cboFrom.SelectedItem.ToString()) || string.IsNullOrEmpty(cboFrom.SelectedItem.ToString()))
			{
				lblConvertedTo.Text = "Missing Amount Value or Currency Selections...";
			}
			else {

				// check what is selected as the From currency
				switch (curFrom)
				{
					case "US Dollar":
						// Now check the options from the To selection
						switch (curTo)
						{
							case "US Dollar":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * us_us;
								if (dblFromAmt > 1)
								{
									lblConvertedTo.Text = us + curAmt + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = us + curAmt + " " + curTo;
								}						
								lblOneFromEqualTo.Text = "1 " + curFrom + " = 1 " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = 1 " + curFrom;
								break;

							case "Euro":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * us_euro;
								if (dblToAmt > 1) {
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								} else
								{
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo; ;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + us_euro.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + euro_us.ToString() + " " + curFrom + "s";
								break;

							case "British Pound":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * us_pound;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								} else
								{
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + us_pound.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + pound_us.ToString() + " " + curFrom + "s";
								break;

							case "Indian Rupee":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * us_rupee;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								} else
								{
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}								
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + us_rupee.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + rupee_us.ToString() + " " + curFrom;
								break;
						}
						break;

					case "Euro":
						// Now check the options from the To selection
						switch (curTo)
						{
							case "Euro":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * euro_euro;
								if (dblFromAmt > 1)
								{
									lblConvertedTo.Text = euro + curAmt + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = euro + curAmt + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = 1 " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = 1 " + curFrom;
								break;

							case "US Dollar":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * euro_us;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo; ;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + euro_us.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + us_euro.ToString() + " " + curFrom;
								break;

							case "British Pound":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * euro_pound;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + euro_pound.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + pound_euro.ToString() + " " + curFrom + "s";
								break;

							case "Indian Rupee":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * euro_rupee;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + euro_rupee.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + rupee_euro.ToString() + " " + curFrom;
								break;
						}

						break;

					case "British Pound":
						// Now check the options from the To selection
						switch (curTo)
						{
							case "British Pound":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * pound_pound;
								if (dblFromAmt > 1)
								{
									lblConvertedTo.Text = pound + curAmt + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = pound + curAmt + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = 1 " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = 1 " + curFrom;
								break;

							case "US Dollar":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * pound_us;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo; ;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + pound_us.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + us_pound.ToString() + " " + curFrom;
								break;

							case "Euro":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * pound_euro;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + pound_euro.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + euro_pound.ToString() + " " + curFrom;
								break;

							case "Indian Rupee":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * pound_rupee;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = rupee + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + pound_rupee.ToString() + " " + curTo + "s";
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + rupee_pound.ToString() + " " + curFrom;
								break;
						}
						break;

					case "Indian Rupee":
						// Now check the options from the To selection
						switch (curTo)
						{
							case "Indian Rupee":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * rupee_rupee;
								if (dblFromAmt > 1)
								{
									lblConvertedTo.Text = rupee + curAmt + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = rupee + curAmt + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = 1 " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = 1 " + curFrom;
								break;

							case "US Dollar":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * rupee_us;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = us + dblToAmt.ToString("#,##0.00") + " " + curTo; ;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + rupee_us.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + us_rupee.ToString() + " " + curFrom + "s";
								break;

							case "Euro":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * rupee_euro;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = euro + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + rupee_euro.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + euro_rupee.ToString() + " " + curFrom + "s";
								break;

							case "British Pound":
								// Calculate the final amount converted by the rate
								dblToAmt = dblFromAmt * rupee_pound;
								if (dblToAmt > 1)
								{
									// Add a "s" to plural of the currency
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo + "s";
								}
								else
								{
									lblConvertedTo.Text = pound + dblToAmt.ToString("#,##0.00") + " " + curTo;
								}
								lblOneFromEqualTo.Text = "1 " + curFrom + " = " + rupee_pound.ToString() + " " + curTo;
								lblOneToEqualFrom.Text = "1 " + curTo + " = " + pound_rupee.ToString() + " " + curFrom + "s";
								break;
						}
						break;
				}
			}
		}

		private void TxtAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			double amount;

			if (double.TryParse(txtAmount.Text, out amount))
			{
				// Store Amount$ value as string
				curAmt = txtAmount.Text;
				dblFromAmt = amount;
				// Update the display
				updateLblAmountFrom();
			}
			else
			{
				// Show an error message if the text in the TextBox is not a valid number
				var dialog = new Windows.UI.Popups.MessageDialog("Please enter a valid number in the Amount field.");
				dialog.ShowAsync();
				return;
			}
			
		}

		private void CboFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Get the ComboBox instance and the selected item
			ComboBox cboFrom = sender as ComboBox;
			ComboBoxItem selectedFromItem = cboFrom.SelectedItem as ComboBoxItem;

			if (selectedFromItem != null)
			{
				// Get the text of the selected item
				curFrom = selectedFromItem.Content.ToString();

				// Update the display
				updateLblAmountFrom();
			}
		}

		private void CboTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Get the ComboBox instance and the selected item
			ComboBox cboFrom = sender as ComboBox;
			ComboBoxItem selectedFromItem = cboFrom.SelectedItem as ComboBoxItem;

			if (selectedFromItem != null)
			{
				// Get the text of the selected item
				curTo = selectedFromItem.Content.ToString();

				// Update the display
				updateLblAmountFrom();
			}
		}
	}
}
