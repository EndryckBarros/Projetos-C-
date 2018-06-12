using System;
using System.Windows;
using System.Windows.Input;
using ViewWPF.DAL;
using ViewWPF.Models;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Usuario u = new Usuario();

        private void btnLogar_Click(object sender, RoutedEventArgs e)
        {
            u = new Usuario();
            u = UsuarioDAO.BuscarUsuarioPorLogin2(txtLogin.Text);
            Program.Batatinha = u.Id;

            if (u != null && TestarSenha(u.Senha))
            {
                PaginaInicial pi = new PaginaInicial();
                pi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login / Senha Incorretos!", "SGCS WPF",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TestarSenha(String senha)
        {
            if (senha.Equals(txtSenha.Password.ToString()))
            {
                return true;
            }
            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CadastrodeUsuario cu = new CadastrodeUsuario();
            cu.Show();
        }
    }

    }

