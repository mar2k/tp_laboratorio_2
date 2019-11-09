using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        /// <summary>
        /// lee el archivo Jornada.txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno;

            Texto textoJornada = new Texto();
            textoJornada.leer("Jornada.txt", out retorno);

            return retorno;
        }

        /// <summary>
        /// muestra los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:\n");
            sb.AppendLine("CLASE DE " + this.Clase + " POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno i in this.Alumnos)
            {
                sb.AppendLine(i.ToString());
            }
            sb.AppendLine("<------------------------------------------->");





            return sb.ToString();
        }

        /// <summary>
        /// guarda el archivo Jornada.txt con los datos actuales
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto textoJornada = new Texto();
            return textoJornada.guardar("Jornada.txt", jornada.ToString());
        }

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// comprueba si el alumno esta en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno i in j.Alumnos)
            {
                if (i == a)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// si el alumno no esta en la jornada lo agrega
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
