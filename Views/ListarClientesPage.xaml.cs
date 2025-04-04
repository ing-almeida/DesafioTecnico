using DesafioTecnico.ViewModels;
using Microsoft.Maui.Controls;

namespace DesafioTecnico.Views
{
    public partial class ListarClientesPage : ContentPage
    {
        public ListarClientesPage()
        {
            InitializeComponent();
            BindingContext = new ClienteViewModel();
        }
    }
}
