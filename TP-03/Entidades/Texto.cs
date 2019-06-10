using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(string));

                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    ser.Serialize(sw, datos);
                }
                retorno = true;
            }
            catch(ArchivosException e)
            {
                throw e;
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(string));
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = (string)ser.Deserialize(sr);
                }

                //sr.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
                //Console.WriteLine(e.ToString());
            }
            return retorno;
        }
    }
}
