using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this String texto, string archivo)
        {
            bool retorno = true;
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(texto);
                sw.Close();
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;
            }
            return retorno;
        }
    }
}
