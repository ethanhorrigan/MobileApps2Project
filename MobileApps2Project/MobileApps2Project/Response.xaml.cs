using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApps2Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Response : ContentPage
	{
		public Response ()
		{
			InitializeComponent ();
            Console.WriteLine("hi");
        }

        public void debugTest()
        {
            Console.WriteLine("hi");
        }
	}
}