using Microsoft.Maui.Controls;
using DesafioTecnico.ViewModels;

namespace DesafioTecnico.Views
{
    public partial class ClientesPage : ContentPage
    {
        public ClientesPage()
        {
            InitializeComponent();
            BindingContext = new ClienteViewModel();
        }
    }
}
