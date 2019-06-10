using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._estadoCuenta = estadoCuenta;
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }

        protected override string MostrarDatos()
        {
            string retorno = base.MostrarDatos() + " - " + this.ParticiparEnClase();

            return retorno;
        }
        protected override string ParticiparEnClase()
        {
            string retorno = "TOMA CLASE DE " + this._claseQueToma.ToString();

            return retorno;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
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
