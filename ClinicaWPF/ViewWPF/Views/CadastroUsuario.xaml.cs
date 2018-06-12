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
    /// Interaction logic for CadastrodeUsuario.xaml
    /// </summary>
    public partial class CadastrodeUsuario : Window
    {
        public CadastrodeUsuario()
        {
            InitializeComponent();
        }

        Usuario u = new Usuario();

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                if (TestarSenha())
                {
                    u = new Usuario()
                    {
                        Login = txtLogin.Text,
                        Senha = txtSenha.Text,
                    };
                    if (UsuarioDAO.SalvarUsuario(u))
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!", "SGCS WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível adicionar o Usuário!", "SGCS WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("As Senhas não Coincidem!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
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

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool TestarSenha()
        {
            if (txtSenha.Text == txtConfirmSenha.Text)
            {
                return true;
            }
            return false;
        }

        public void LimparCampos()
        {
            txtLogin.Clear();
            txtSenha.Clear();
            txtConfirmSenha.Clear();
            txtLogin.Focus();
        }
    }
}
