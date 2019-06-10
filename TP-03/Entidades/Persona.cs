using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get
            { return this._apellido; }
            set
            { this._apellido = this.ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get
            { return this._dni; }
            set
            {
                try
                {

                    this._dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (NacionalidadInvalidaException)
                {
                    Console.WriteLine("NacionalidadInvalidaException");
                }

            }
        }

        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = this.ValidarDni(this.Nacionalidad, int.Parse(value));
                }
                catch (DniInvalidoException e)
                {
                    Console.WriteLine("NacionalidadInvalidaException");

                    throw e;
                }

            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            { return this._nacionalidad; }
            set
            { this._nacionalidad = value; }
        }
        public string Nombre
        {
            get
            { return this._nombre; }
            set
            { this._nombre = this.ValidarNombreApellido(value); }
        }

        public Persona() : this("", 0, ENacionalidad.Argentino, "")
        {
        }

        public Persona(string apellido, int dni, ENacionalidad nacionalidad, string nombre)
        {

            this.Apellido = apellido;
            this.DNI = dni;
            this.Nacionalidad = nacionalidad;
            this.Nombre = nombre;
        }

        public Persona(string apellido, ENacionalidad nacionalidad, string nombre)
        {
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            Nombre = nombre;
        }

        public Persona(string apellido, string stringToDNI, ENacionalidad nacionalidad, string nombre)
        {
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = stringToDNI;
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return "Nombre: " + this.Nombre + " - Apellido: " + this.Apellido + " - DNI: " + this.DNI.ToString() + " - Nacionalidad: " + this.Nacionalidad.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;



            if (dato >= 1 && dato <= 99999999)
            {
                if (dato <= 89999999 && nacionalidad == ENacionalidad.Argentino)
                {
                    retorno = dato;
                }
                else if (dato >= 90000000 && nacionalidad == ENacionalidad.Extranjero)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return this.ValidarDni(nacionalidad, int.Parse(dato));
        }
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            retorno = dato;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!Char.IsLetter(dato, i) && dato[i] != ' ')
                {
                    retorno = "";
                    break;
                }
            }
            return retorno;
        }
    }
}
