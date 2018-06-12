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
    /// Interaction logic for MedicosCadastrados.xaml
    /// </summary>
    public partial class MedicosCadastrados : Window
    {
        public List<Medico> MeusMedicos { get; set; }

        public MedicosCadastrados()
        {
            InitializeComponent();
            MeusMedicos = MedicoDAO.ListagemFiltradaDeMedicos(Program.Batatinha);
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
