using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornadas;
        private List<Profesor> _profesors;


        public List<Alumno> Alumnos
        {
            get => _alumnos;
            set => _alumnos = value;
        }
        public List<Jornada> Jornadas
        {
            get => _jornadas;
            set => _jornadas = value;
        }
        public List<Profesor> Profesors
        {
            get => _profesors;
            set => _profesors = value;
        }
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }


        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesors = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno = "<----------------------------------------------->\nPROFESORES \n\n";

            foreach (Profesor item in uni.Profesors)
            {
                retorno += item.ToString()+"\n";
            }
            retorno += "<----------------------------------------------->\nALUMNOS \n\n";
            foreach (Alumno item in uni.Alumnos)
            {
                retorno += item.ToString() + "\n";
            }
            retorno += "<----------------------------------------------->\nJORNADA\n\n";
            foreach (Jornada item in uni.Jornadas)
            {
                retorno += item.ToString() + "\n";
            }
            return retorno;
        }
        
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Jornada item in g.Jornadas)
            {
                if (i == item.Clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            bool flag = false;
            foreach (Profesor item in u.Profesors)
            {
                if (item == clase)
                {
                    retorno = item;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new SinProfesorException();
            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return new Profesor();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                u.Alumnos.Add(a);
            }
            return u;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u.Profesors.Count != 0)
            {
                if (u != i)
                {
                    u.Profesors.Add(i);
                }
            }
            else
            {
                u.Profesors.Add(i);
            }

            return u;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    jornada.Alumnos.Add(item);
                }
            }
            g.Jornadas.Add(jornada);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            IArchivo<Universidad> archivo = new Xml<Universidad>();
            return archivo.Guardar(@".\Universidad.Xml", uni);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            IArchivo<Universidad> archivo = new Xml<Universidad>();
            archivo.Leer(@".\Universidad.Xml", out retorno);
            return retorno;
        }
    }
}
