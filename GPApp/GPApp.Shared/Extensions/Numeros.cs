using System;

namespace GPApp.Shared.Extensions
{
    public static class Numeros
    {

        public static short ToShort(this int valor)
        {
            return Convert.ToInt16(valor);
        }

    }
}
