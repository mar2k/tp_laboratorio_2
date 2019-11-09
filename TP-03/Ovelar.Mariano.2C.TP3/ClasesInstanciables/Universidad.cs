using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// si el indice pasado es valido setea o retorna la instancia de jornada pasada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i <= Jornadas.Count)
                    return this.Jornadas[i];

                return null;
            }
            set
            {
                if (i >= 0 && i < jornada.Count)
                    this.Jornadas[i] = value;
            }
        }

        public Universidad()
        {
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// muestra los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// guarda los datos de la instancia pasada por parametro en un archivo xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> miUni = new Xml<Universidad>();

            return miUni.guardar("Universidad.xml", ((Universidad)gim));

        }


        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada i in gim.Jornadas)
            {
                sb.AppendLine(i.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// retorna true si el alumno ya forma parte de la universidad, false caso contrario.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno i in g.Alumnos)
            {
                if (i.Equals(a))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// devuelve al primer profesor capaz de dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p == clase)
                    return p;
            }

            throw new SinProfesorException("No hay ningun profesor disponible"); ;
        }

        /// <summary>
        /// indica si el profesor ya da clases en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor pf in g.Instructores)
            {
                if (pf == i)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// devuelve el primer profesor que no puede dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException("Todos los profesores pueden dar esta clase");
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// agrega un alumno a la universidad si no pertenece previamente, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido!");
            }
            return g;
        }

        /// <summary>
        /// genera una nueva jornada con un profesor que la da y los alumnos que la toman y la agrega a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.Instructores)
            {
                if (i == clase)
                {
                    Jornada jornada = new Jornada(clase, i);

                    foreach (Alumno a in g.Alumnos)
                    {
                        if (a == clase)
                            jornada.Alumnos.Add(a);
                    }

                    g.Jornadas.Add(jornada);
                    break;
                }
                throw new SinProfesorException("No hay profesor que de esa clase");
            }

            return g;

        }

        /// <summary>
        /// si el profesor no pertenece a la universidad lo agrega
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
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
