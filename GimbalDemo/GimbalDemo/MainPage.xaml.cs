using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GimbalDemo.Interface;
using Xamarin.Forms;

namespace GimbalDemo
{
    public partial class MainPage : ContentPage
    {
        private Action<string> statusAction;
        public MainPage()
        {
            InitializeComponent();

            statusAction += setStatus;

            DependencyService.Get<IGimbalService>().Initialize(statusAction);
        }

        private void OnGimbalStartClicked(object sender, EventArgs args)
        {
            DependencyService.Get<IGimbalService>().Start();
        }

        private void OnGimbalStopClicked(object sender, EventArgs args)
        {
            DependencyService.Get<IGimbalService>().Stop();
        }

        private void setStatus(string status) {
            lblStatus.Text = status;
        }
    }
}
