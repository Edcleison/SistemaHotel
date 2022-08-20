using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace SistemaHotel.Utils
{
    public class SenhaRandomica
    {
        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz";
        private const string SenhaNumerosValidos = "1234567890";

        public static string RandLetras(int tamanho)
        {
            int valormaximo = SenhaCaracteresValidos.Length;

            Random random = new Random(DateTime.Now.Millisecond);

            StringBuilder senha = new StringBuilder(tamanho);

            for (int indice = 0; indice < tamanho; indice++)
                senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);

            return senha.ToString();
        }
        public static string RandNumeros(int tamanho)
        {
            int valormaximo = SenhaNumerosValidos.Length;

            Random random = new Random(DateTime.Now.Millisecond);

            StringBuilder senha = new StringBuilder(tamanho);

            for (int indice = 0; indice < tamanho; indice++)
                senha.Append(SenhaNumerosValidos[random.Next(0, valormaximo)]);

            return senha.ToString();
        }
    }
}