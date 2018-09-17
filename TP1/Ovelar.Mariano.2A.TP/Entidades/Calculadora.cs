using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
        private static String ValidarOperador(String operador)
        {
            String retorno = "+";

            if(operador=="-" || operador == "+" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }

            return retorno;

        }

        public static double  Operar(Numero num1, Numero num2, String operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);

            if (operador == "-")
            {
                retorno = num1 - num2;
            }
            else if(operador == "*")
            {
                retorno = num1 * num2;
            }
            else if (operador == "/")
            {
                retorno = num1 / num2;
            }
            else
            {
                retorno = num1 + num2;
            }

            return retorno;    
        }
    }
}
