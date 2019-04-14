using System;
using System.Collections.Generic;
using System.Text;

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
        public Numero()
        {
            this._numero = 0;
        }


        private static double ValidarNumero (String strNumero)
        {
            double retorno = 0;
            bool flag = true;

            foreach (char numero in strNumero)
            {
                if(!(numero >= '0' && numero <= '9'))
                {
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                if(strNumero=="")
                {
                    strNumero = "0";
                }
                retorno = double.Parse(strNumero);
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
            String cadena = "";
            String aux = x.ToString();
            int numero =int.Parse(aux);
            if (numero > 0)
            {
                
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                }
            }
            else
            {
                cadena = "0";
            }
            /*charArray = bin.ToCharArray();
            Array.Reverse(charArray);*/
            /*return new string(charArray);*/
            return cadena;
        }

        public static String BinarioDecimal(String binario)
        {
            String retorno="Valor inválido";
            char[] array = binario.ToCharArray();
            bool flag = true;

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] != '1' && array[i] != '0')
                {
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                Array.Reverse(array);
                double sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        sum += (double)Math.Pow(2, i);
                    }
                }
                retorno = sum.ToString();
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
            if(n2._numero!=0)
            {
                retorno=n1._numero / n2._numero;
            }
            return retorno; 
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

    }
}
