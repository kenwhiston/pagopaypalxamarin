using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PagoPaypal.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class SuccessPopUp : PopupPage
    {
        public SuccessPopUp()
        {
            this.InitializeComponent();
        }
        async void OnClosePopUp(object sender, EventArgs e)
        {
            await PopupNavigation.PopAllAsync();
        }
        
    }
}
