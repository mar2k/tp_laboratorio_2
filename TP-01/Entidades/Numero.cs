using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        public String SetNumero
        {
            set
            {
                this._numero = ValidarNumero(value);
            }
        }
        public Numero() : this("0") { }

        public Numero(double numero) : this(numero.ToString()) { }

        public Numero(string numero)
        {
            if (numero != "")
            {
                this.SetNumero = numero;
            }
        }

        private static double ValidarNumero(String strNumero)
        {
            double retorno;

            if (!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }

            return retorno;
        }

        public static String DecimalBinario(String numero)
        {
            bool flag = true;

            foreach (char num in numero)
            {
                if (!(num >= '0' && num <= '9'))
                {
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                numero = "0";
            }

            return DecimalBinario(double.Parse(numero));
        }

        public static String DecimalBinario(double x)
        {
            String Retorno = "";

            Retorno = Convert.ToString(Convert.ToInt32(x), 2);


            return Retorno;
        }

        public static String BinarioDecimal(String binario)
        {
            String retorno = "Valor inválido";

            char[] array = binario.ToCharArray();
            bool flag = true;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '1' && array[i] != '0')
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }
            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if (n2._numero != 0)
            {
                retorno = n1._numero / n2._numero;
            }
            return retorno;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

    }
}
