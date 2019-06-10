using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace Entidades
{
    public class Xml<T> : IArchivo <T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {

            try
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Xml<T>));
                using (StreamWriter streamWriter = new StreamWriter(archivo))
                {
                    xmlSerializer.Serialize (streamWriter, datos);
                }
                XmlSerializer ser = new XmlSerializer(typeof(T));


            }
            catch (Exception e)
            {
                //return false;
                throw e.InnerException;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
           
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));

                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos=(T)ser.Deserialize(sr);
                }

            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
            return true;
        }
    }
}
