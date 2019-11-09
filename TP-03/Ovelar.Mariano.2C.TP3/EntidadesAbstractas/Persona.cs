using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string _apellido;
        private string _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;

        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (ValidarNombreApellido(value) != "INV")
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = value; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set
            {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                {
                    this._nacionalidad = value;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad es inválida!");
                }
            }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (ValidarNombreApellido(value) != "INV")
                {
                    this._nombre = value;
                }
            }
        }

        /// <summary>
        /// intenta setear un dni pasado en forma de string llamando a la func ValidarDni()
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int aux = ValidarDni(this.Nacionalidad, value);

                if (aux != 0)
                {
                    DNI = aux;
                }
                else
                {
                    throw new DniInvalidoException("El DNI ingresado es inválido.");
                }
            }
        }

        public Persona() : this("", "", ENacionalidad.Argentino)
        { }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("DNI: " + this.DNI);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// comprueba si el dni "dato" condice con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 1 && dato <= 89999999)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                    return dato;
            }
            else if (dato > 89999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                    return dato;
            }

            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
        }

        /// <summary>
        /// intenta parsear el dni en forma de string "dato" y se lo pasa a ValidarDni()
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = 0;
            int.TryParse(dato, out aux);

            return ValidarDni(nacionalidad, aux);
        }

        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            {
                return dato;
            }
            return "INV";
        }
    }
}
