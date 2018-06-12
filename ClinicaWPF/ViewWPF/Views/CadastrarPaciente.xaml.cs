using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewWPF.DAL;
using ViewWPF.Models;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for CadastrarPaciente.xaml
    /// </summary>
    public partial class CadastrarPaciente : Window
    {
        public CadastrarPaciente()
        {
            InitializeComponent();
        }

        Paciente p = new Paciente();

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                p = new Paciente
                {
                    Nome = txtNome.Text,
                    CPF = txtCpf.Text,
                    Telefone = txtTelefone.Text,
                    UsuarioId = Program.Batatinha
                };
                if (PacienteDAO.SalvarPaciente(p))
                {
                    MessageBox.Show("Paciente cadastrado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            btnGravar.IsEnabled = false;
            btnAlterar.IsEnabled = true;

            if (!string.IsNullOrEmpty(txtCpf.Text))
            {
                p = new Paciente
                {
                    CPF = txtCpf.Text
                };
                p = PacienteDAO.BuscarPacientePorCPF(p);
                if (p != null)
                {
                    txtNome.Text = p.Nome;
                    txtCpf.Text = p.CPF;
                    txtTelefone.Text = p.Telefone;
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                p.Nome = txtNome.Text;
                p.CPF = txtCpf.Text;
                if (PacienteDAO.AlterarPaciente(p))
                {
                    MessageBox.Show("Paciente alterado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }



    }
}
