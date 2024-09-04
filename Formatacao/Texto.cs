namespace Formatacao
{
    public static class Texto
    {
        public static string Left(this string valor, int length)
        {
            if (valor != null)
                return (valor.Length >= length ? valor.Substring(0, length) : valor);
            else
                return string.Empty;
        }

        public static string Right(this string valor, int length)
        {
            if (valor != null)
                return (valor.Length >= length ? valor.Substring(valor.Length - length, length) : valor);
            else
                return string.Empty;
        }
    }
}
