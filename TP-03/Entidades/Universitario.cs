using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public Universitario() : base()
        {
            this._legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(apellido,dni,nacionalidad,nombre)
        {
            this._legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            string retorno = base.ToString() + "- Legajo: " + this._legajo.ToString();

            return retorno;
        }
        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return (obj is Universitario && ((Universitario)obj) == this);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
