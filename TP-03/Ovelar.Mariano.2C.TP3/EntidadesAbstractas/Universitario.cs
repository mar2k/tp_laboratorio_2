using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo: " + this._legajo);

            return sb.ToString();
        }

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1._legajo == pg2._legajo || pg2.DNI == pg1.DNI)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
