using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class SegridadBL
    {
        Contexto _contexto;

        public SegridadBL()
        {
            _contexto = new Contexto();
        }

        public bool Autorizar(string usuario, string contraseña)
        {

            var usuarios = _contexto.Usuarios.ToList();


            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contraseña == usuarioDB.Contraseña)
                {
                    return true;
                }
            }

            return false;
        }
    }
}