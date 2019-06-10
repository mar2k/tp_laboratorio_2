using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor : Universitario
    {
        private static Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private static void _randomClases()
        {
            Profesor.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            Profesor.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        static Profesor()
        {
            Profesor.random = new Random();
            Profesor.clasesDelDia = new Queue<Universidad.EClases>();
            Profesor._randomClases();
        }
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
        }

        protected override string MostrarDatos()
        {
            string retorno = base.MostrarDatos()+" - " + this.ParticiparEnClase(); ;

            return retorno;
        }
        protected override string ParticiparEnClase()
        {
            string retorno = "\nCLASES DEL DÍA:\n";

            foreach (Universidad.EClases item in Profesor.clasesDelDia)
            {
                retorno += item.ToString() + "\n";
            }

            return retorno;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in Profesor.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
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
