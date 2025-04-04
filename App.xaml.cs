using DesafioTecnico.Views;
using DesafioTecnico.ViewModels;
using Microsoft.Maui.Controls;

namespace DesafioTecnico
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Criação do ViewModel antes de passar para a View
            var clienteViewModel = new ClienteViewModel();

            // Passando o ViewModel como parâmetro para a Page
            MainPage = new NavigationPage(new CadastroClientePage(clienteViewModel));
        }
    }
}
