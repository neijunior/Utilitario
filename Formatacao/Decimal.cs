using System;
using System.Collections.Generic;
using System.Text;

namespace Formatacao
{
  public static class Decimal
  {
    public static decimal Truncar(this decimal valor, int qtdCasas = 2)
    {
      int valorCasas = ($"1{("").PadLeft(qtdCasas, '0')}").ToInt();
      return Math.Truncate(valorCasas * valor) / 100;
    }
  }
}
