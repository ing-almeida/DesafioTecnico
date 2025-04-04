using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DesafioTecnico.Models;

namespace DesafioTecnico.ViewModels
{
    public class ClienteViewModel : BindableObject
    {
        private string _nome;
        private string _idade;
        private string _endereco;
        private Cliente _clienteSelecionado;
        private string _textoBotao = "Adicionar Cliente";

        public ObservableCollection<Cliente> Clientes { get; } = new ObservableCollection<Cliente>();

        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        public string Idade
        {
            get => _idade;
            set
            {
                _idade = value;
                OnPropertyChanged();
            }
        }

        public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;
                OnPropertyChanged();
            }
        }

        public string TextoBotao
        {
            get => _textoBotao;
            set
            {
                _textoBotao = value;
                OnPropertyChanged();
            }
        }

        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                _clienteSelecionado = value;
                if (_clienteSelecionado != null)
                {
                    Nome = _clienteSelecionado.Nome;
                    Idade = _clienteSelecionado.Idade.ToString();
                    Endereco = _clienteSelecionado.Endereco;
                    TextoBotao = "Salvar Edição";
                }
                else
                {
                    TextoBotao = "Adicionar Cliente";
                }
                OnPropertyChanged();
            }
        }

        public ICommand AdicionarOuEditarClienteCommand { get; }
        public ICommand ExcluirClienteCommand { get; }
        public ICommand SelecionarClienteCommand { get; }

        public ClienteViewModel()
        {
            // Coloquei esses clientes para já estarem listados no primeiro acesso do usuário
            Clientes.Add(new Cliente { Nome = "Ingrid Almeida", Idade = 28, Endereco = "S. Dumont, 145" });
            Clientes.Add(new Cliente { Nome = "Carlos Oliveira", Idade = 35, Endereco = "Dom Luís, 496" });
            Clientes.Add(new Cliente { Nome = "Mariana Lima", Idade = 22, Endereco = "Rua Central, 789" });

            AdicionarOuEditarClienteCommand = new Command(async () => await AdicionarOuEditarCliente());
            ExcluirClienteCommand = new Command<Cliente>(async (cliente) => await ExcluirCliente(cliente));
            SelecionarClienteCommand = new Command<Cliente>(SelecionarCliente);
        }

        private async Task AdicionarOuEditarCliente()
        {
            if (!string.IsNullOrWhiteSpace(Nome) && !string.IsNullOrWhiteSpace(Idade) && !string.IsNullOrWhiteSpace(Endereco))
            {
                if (int.TryParse(Idade, out int idadeConvertida))
                {
                    if (ClienteSelecionado == null)
                    {
                        Clientes.Add(new Cliente { Nome = Nome, Idade = idadeConvertida, Endereco = Endereco });
                        await Application.Current.MainPage.DisplayAlert("Sucesso", "Cliente adicionado com sucesso!", "OK");
                    }
                    else
                    {
                        ClienteSelecionado.Nome = Nome;
                        ClienteSelecionado.Idade = idadeConvertida;
                        ClienteSelecionado.Endereco = Endereco;
                        await Application.Current.MainPage.DisplayAlert("Editado", "Cliente editado com sucesso!", "OK");
                        ClienteSelecionado = null;
                    }

                    Nome = string.Empty;
                    Idade = string.Empty;
                    Endereco = string.Empty;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "A idade deve ser um número válido!", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Preencha todos os campos antes de adicionar.", "OK");
            }
        }

        private void SelecionarCliente(Cliente cliente)
        {
            ClienteSelecionado = cliente;
        }

        private async Task ExcluirCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                bool confirmar = await Application.Current.MainPage.DisplayAlert("Confirmar", $"Deseja remover {cliente.Nome}?", "Sim", "Cancelar");

                if (confirmar)
                {
                    Clientes.Remove(cliente);
                    await Application.Current.MainPage.DisplayAlert("Removido", "Cliente removido com sucesso!", "OK");
                }
            }
        }
    }
}
