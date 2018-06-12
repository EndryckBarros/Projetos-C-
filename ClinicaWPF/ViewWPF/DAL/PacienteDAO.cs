using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ViewWPF.Models;

namespace ViewWPF.DAL
{
    class PacienteDAO
    {

        private static Context ctx = Singleton.Instance.Context;

        public static bool SalvarPaciente(Paciente paciente)
        {
            if (BuscarPacientePorCPF(paciente) == null)
            {
                try
                {
                    ctx.Pacientes.Add(paciente);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool AlterarPaciente(Paciente paciente)
        {
            try
            {
                ctx.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Paciente BuscarPacientePorCPF(Paciente paciente)
        {
            return ctx.Pacientes.FirstOrDefault(x => x.CPF.Equals(paciente.CPF));
        }

        public static List<Paciente> ListagemDePacientes()
        {
            return ctx.Pacientes.ToList();
        }

        public static List<Paciente> ListagemFiltradaDePacientes(int id)
        {
            //List<Paciente> ListaFiltrada = new List<Paciente>();

            //foreach (Paciente pacienteTestado in ctx.Pacientes.ToList())
            //{
            //    if (pacienteTestado.UsuarioId.Equals(id))
            //    {
            //        ListaFiltrada.Add(pacienteTestado);
            //    }
            //}
            //return ListaFiltrada;

            return ctx.Pacientes.Where(p => p.UsuarioId == id).ToList();
        }

        public static int Contagem()
        {
            List<Paciente> ListaFiltrada = new List<Paciente>();
            ListaFiltrada = ListagemFiltradaDePacientes(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }
    }
}
