
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinDataBinding
{
	public partial class MainPage : ContentPage
	{
        DateViewModel context;

        public MainPage()
		{
            context = new DateViewModel();
            context.PropertyChanged += Context_PropertyChanged;
            this.BindingContext = context;


            InitializeComponent();
		}

        private void Context_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(string.Format("{0} : {1} - {2}", e.PropertyName, "", "")); 
        }

        public void applyChange()
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            applyChange();
        }
    }
}
