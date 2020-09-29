using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace payroll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayrollPage : ContentPage
    {
        public PayrollPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set global variables then close the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            // set global variables
            GlobalPayrollVariables.Hours = double.Parse(txtBoxHours.Text);
            GlobalPayrollVariables.Pay = decimal.Parse(txtBoxRate.Text);
            // close the page
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}