using System;
using DesafioTecnico.ViewModels;
using Microsoft.Maui.Controls;

namespace DesafioTecnico.Views
{
    public partial class CadastroClientePage : ContentPage
    {
        public CadastroClientePage(ClienteViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public CadastroClientePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        // O item depois de "clicado" fica com aspecto de "pisca" e depois apaga (isso é para o usuário entender que clicou no nome)
        private void ClientesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender is ListView listView)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
