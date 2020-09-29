using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace payroll
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show the payroll page and then calculate pay from user input. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCalculate_Clicked(object sender, EventArgs e)
        {
            // declare variables
            double overtimeHours;
            decimal overtimePay, pay;
            //Show the payroll page as a modal
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var modalPage = new PayrollPage();
            modalPage.Disappearing += (sender2, e2) =>
            {
                waitHandle.Set();
            };
            await Navigation.PushModalAsync(modalPage);
            await Task.Run(() => waitHandle.WaitOne());
            // Calculate payroll for overtime
            if (GlobalPayrollVariables.Hours > 40)
            {
                //Calculate overtime hours
                overtimeHours = GlobalPayrollVariables.Hours - 40;
                //Calculate overtime pay
                overtimePay = (GlobalPayrollVariables.Pay * 1.5m) * (decimal)overtimeHours;
                //Calculate gross pay
                pay = GlobalPayrollVariables.Pay * 40 + overtimePay;
            }
            //else calculate payroll for normal pay
            else
            {
                //Calculate gross pay
                pay = GlobalPayrollVariables.Pay * (decimal)GlobalPayrollVariables.Hours;

            }
            //show results
            lblResults.Text = pay.ToString("c");
        }
    }
}
