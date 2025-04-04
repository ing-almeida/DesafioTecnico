using DesafioTecnico.Views;
using Microsoft.Maui.Controls;

namespace DesafioTecnico
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CadastroClientePage), typeof(CadastroClientePage));
        }
    }
}
