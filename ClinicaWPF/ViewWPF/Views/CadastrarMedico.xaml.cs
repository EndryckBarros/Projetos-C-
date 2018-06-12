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
    /// Interaction logic for CadastrarMedico.xaml
    /// </summary>
    public partial class CadastrarMedico : Window
    {
        public CadastrarMedico()
        {
            InitializeComponent();
        }

        Medico m = new Medico();

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                m = new Medico()
                {
                    Nome = txtNome.Text,
                    CPF = txtCpf.Text,
                    Especialidade = txtEspecialidade.Text,
                    UsuarioId = Program.Batatinha
                };
                if (MedicoDAO.SalvarMedico(m))
                {
                    MessageBox.Show("Medico cadastrado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o Medico!", "SGCS WPF",
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
                m = new Medico
                {
                    CPF = txtCpf.Text
                };
                m = MedicoDAO.BuscarMedicoPorCPF(m);
                if (m != null)
                {
                    txtNome.Text = m.Nome;
                    txtCpf.Text = m.CPF;
                    txtEspecialidade.Text = m.Especialidade;
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Medico!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    m = new Medico
                    {
                        Nome = txtNome.Text
                    };
                    m = MedicoDAO.BuscarMedicoPorNome(m);
                    if (m != null)
                    {
                        txtNome.Text = m.Nome;
                        txtCpf.Text = m.CPF;
                        txtEspecialidade.Text = m.Especialidade;
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                m.Nome = txtNome.Text;
                m.CPF = txtCpf.Text;
                m.Especialidade = txtEspecialidade.Text;

                if (MedicoDAO.AlterarMedico(m))
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
            txtEspecialidade.Clear();
            txtNome.Focus();
        }
    }
}
