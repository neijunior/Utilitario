using System;
using System.Collections.Generic;
using System.Text;

namespace Formatacao
{
  public static class CpfCnpj
  {
    public static string FormatarCpfCnpj(this string valor)
    {
      if (valor.Length == 11)
        return Convert.ToUInt64(valor).ToString("000\\.000\\.000\\-00");
      else
        return Convert.ToUInt64(valor).ToString("00\\.000\\.000\\/0000\\-00");
    }
  }
}
