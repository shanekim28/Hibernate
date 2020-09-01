using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hibernate.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WakeUpView : ContentPage {
        public WakeUpView() {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e) {
            Navigation.PopModalAsync(true);
        }
    }
}