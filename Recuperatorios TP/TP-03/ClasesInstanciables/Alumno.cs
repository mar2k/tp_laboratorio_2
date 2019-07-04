using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// devuelve los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// devuelve las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this._claseQueToma;
        }

        /// <summary>
        /// si no es deudor y toma la clase devuelve true
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
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
