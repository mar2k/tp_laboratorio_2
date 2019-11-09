using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>

    {
        /// <summary>
        /// toma los datos y los guarda en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {

                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @archivo, false))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("No se pudo guardar el archivo de texto");
            }
        }

        /// <summary>
        /// lee los datos de el path archivo y los pasa a una variable para mostrarlos por consola
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                datos = "";


                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @archivo, true))
                {
                    while (sr.EndOfStream == false)
                    {
                        datos += sr.ReadLine()+"\n";

                        //lee hasta el salto de linea
                        //Console.WriteLine(datos);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("No se leer guardar el archivo de texto");
            }
        }
    }
}
