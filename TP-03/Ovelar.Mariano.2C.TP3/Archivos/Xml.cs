using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        /// <summary>
        /// guarda datos de tipo T en el path de archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {

                using (TextWriter tw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @archivo, false))
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(T), "");

                    xmlS.Serialize(tw, datos);
                }

                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("No se pudo guardar el archivo XML");
            }
        }

        /// <summary>
        /// lee datos de tipo T desd eel path archivo xml y los guarda en una variable para mostrarlo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                datos = new T();

                using (TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @archivo, true))
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(T), datos.ToString());

                    T p = (T)xmlS.Deserialize(tr);
                    Console.WriteLine(p.ToString());
                }

                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("No se pudo leer el archivo XML");
            }
        }
    }
}
