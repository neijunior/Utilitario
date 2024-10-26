using System;
using System.Collections.Generic;
using System.Text;

namespace Formatacao
{
  public static class Converter
  {
    public static int ToInt(this string valor)
    {
      int ret = default(int);
      if (!string.IsNullOrEmpty(valor))
        ret = Convert.ToInt32(valor);
      return ret;
    }
  }
}
