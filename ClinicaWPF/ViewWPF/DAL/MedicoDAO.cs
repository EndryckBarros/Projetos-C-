using System;
using System.Collections.Generic;
using System.Linq;
using ViewWPF.Models;

namespace ViewWPF.DAL
{
    class MedicoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool SalvarMedico(Medico medico)
        {
            if (BuscarMedicoPorCPF(medico) == null)
            {
                try // CAMINHO FELIZ
                {
                    ctx.Medicos.Add(medico);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool AlterarMedico(Medico medico)
        {
            try
            {
                ctx.Entry(medico).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Medico ProcurarMedicoPorId(int id)
        {
            return ctx.Medicos.Find(id);
        }

        public static Medico BuscarMedicoPorCPF(Medico medico)
        {
            return ctx.Medicos.FirstOrDefault(x => x.CPF.Equals(medico.CPF));
        }

        public static Medico BuscarMedicoPorNome(Medico medico)
        {
            return ctx.Medicos.FirstOrDefault(x => x.Nome.Equals(medico.Nome));
        }

        public static List<Medico> ListagemDeMedicos()
        {
            return ctx.Medicos.ToList();
        }

        public static List<Medico> ListagemFiltradaDeMedicos(int id)
        {
            List<Medico> ListaFiltrada = new List<Medico>();

            foreach (Medico medicoTestado in ctx.Medicos.ToList())
            {
                if (medicoTestado.UsuarioId.Equals(id))
                {
                    ListaFiltrada.Add(medicoTestado);
                }
            }
            return ListaFiltrada;
        }

        public static int Contagem()
        {
            List<Medico> ListaFiltrada = new List<Medico>();
            ListaFiltrada = ListagemFiltradaDeMedicos(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }

    }
}
