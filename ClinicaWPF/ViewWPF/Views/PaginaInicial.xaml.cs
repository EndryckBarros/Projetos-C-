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

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for PaginaInicial.xaml
    /// </summary>
    public partial class PaginaInicial : Window
    {
        public PaginaInicial()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void cadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarPaciente cp = new CadastrarPaciente();
            cp.Show();
        }

        private void cadastrarMedico_Click(object sender, RoutedEventArgs e)
        {
            CadastrarMedico cm = new CadastrarMedico();
            cm.Show();
        }

        private void cadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            CadastrodeUsuario cu = new CadastrodeUsuario();
            cu.Show();
        }

        private void ListMedicos_Click(object sender, RoutedEventArgs e)
        {
            MedicosCadastrados mc = new MedicosCadastrados();
            mc.Show();
        }

        private void ListPacientes_Click(object sender, RoutedEventArgs e)
        {
            PacientesCadastrados pc = new PacientesCadastrados();
            pc.Show();
        }
    }
}
