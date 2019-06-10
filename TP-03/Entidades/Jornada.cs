using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Entidades
{
    public class Jornada
    {
        private static List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get
            { return Jornada._alumnos; }
            set
            { Jornada._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        internal Profesor Instructor
        {
            get
            { return this._instructor; }
            set
            { this._instructor = value; }
        }
        static Jornada()
        {
            Jornada._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clases, Profesor instructor)
        {
            this.Clase = clases;
            this._instructor = instructor;
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(@".\Jornada.Xml", jornada.ToString());
        }
        public string Leer()
        {
            string retorno;
            Texto texto = new Texto();
            texto.Leer(@".\Jornada.Xml", out retorno);
            return retorno;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        public override string ToString()
        {
            string retorno = "CLASE: " + this._clase.ToString() + "\nPROFESOR: " + this._instructor.ToString() + "\nALUMNOS:\n";
            foreach (Alumno item in Jornada._alumnos)
            {
                retorno += item.ToString()+"\n";
            }
            return retorno;
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
