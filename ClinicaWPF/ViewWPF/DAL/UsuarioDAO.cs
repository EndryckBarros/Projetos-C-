using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewWPF.Models;

namespace ViewWPF.DAL
{
    class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool SalvarUsuario(Usuario usuario)
        {
            if (BuscarUsuarioPorLogin(usuario) == null)
            {
                try
                {
                    ctx.Usuarios.Add(usuario);
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

        public static bool AlterarUsuario(Usuario usuario)
        {
            try
            {
                ctx.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Usuario BuscarUsuarioPorLogin(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login));
        }

        public static Usuario BuscarUsuarioPorLogin2(String login)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(login));
        }

    }
}
