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
    /// Interaction logic for PacientesCadastrados.xaml
    /// </summary>
    public partial class PacientesCadastrados : Window
    {
        public List<Paciente> MeusPacientes { get; set; }

        public PacientesCadastrados()
        {
            InitializeComponent();
            MeusPacientes = PacienteDAO.ListagemFiltradaDePacientes(Program.Batatinha);
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
