using System.Linq;

namespace Validacao
{
  public static class CpfCnpj
  {
    public static bool ValidarCnpj(this string value)
    {
      int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
      int soma = 0;
      int resto = 0;
      string digito = null;
      string tempCnpj = null;

      if (string.IsNullOrEmpty(value))
      {
        return false;
      }
      value = value.Trim();
      value = value.Replace(".", "").Replace("-", "").Replace("/", "");

      if (CnpjCpfTodoCaracIgual(value))
      {
        return false;
      }

      if (value.Length != 14)
      {
        return false;
      }

      tempCnpj = value.Substring(0, 12);
      soma = 0;

      for (int i = 0; i <= 11; i++)
      {
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
      }

      resto = (soma % 11);
      if (resto < 2)
      {
        resto = 0;
      }
      else
      {
        resto = 11 - resto;
      }

      digito = resto.ToString();
      tempCnpj = tempCnpj + digito;
      soma = 0;

      for (int i = 0; i <= 12; i++)
      {
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
      }

      resto = (soma % 11);
      if ((resto < 2))
      {
        resto = 0;
      }
      else
      {
        resto = 11 - resto;
      }

      digito = digito + resto.ToString();
      return value.EndsWith(digito);
    }

    public static bool ValidarCpf(this string cpf)
    {
      int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digito;
      int soma;
      int resto;

      if (string.IsNullOrEmpty(cpf))
      {
        return false;
      }

      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");

      if (CnpjCpfTodoCaracIgual(cpf))
      {
        return false;
      }

      if (cpf.Length != 11)
        return false;

      tempCpf = cpf.Substring(0, 9);
      soma = 0;

      for (int i = 0; i < 9; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = resto.ToString();
      tempCpf = tempCpf + digito;
      soma = 0;
      for (int i = 0; i < 10; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = digito + resto.ToString();
      return cpf.EndsWith(digito);
    }

    private static bool CnpjCpfTodoCaracIgual(string valor)
    {
      char c = valor[0];
      return valor.All(a => a == c);
    }
  }
}
