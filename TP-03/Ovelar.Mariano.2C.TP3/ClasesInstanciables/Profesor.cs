using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random random;

        /// <summary>
        /// muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// devuelve las clases del dia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DEL DIA: \n");

            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                sb.Append(clase + "\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// devuelve true si el profesor da la clase en el dia
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases e in i._clasesDelDia)
            {
                if (e == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// genera un numero random, lo castea a EClases y lo agrega a la queue del profesor dos veces
        /// </summary>
        private void _randomClases()
        {
            int i = 0;
            while (i < 2)
            {
                _clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
                i++;
            }
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
