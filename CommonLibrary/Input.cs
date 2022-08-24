using System;

namespace CommonLibrary
{
  /// <summary>
  /// Входные данные.
  /// </summary>
  [Serializable]
  public class Input
  {
    /// <summary>
    /// Коэффицент.
    /// </summary>
    public int K { get; set; }

    /// <summary>
    /// Массив элементов для операции суммирования.
    /// </summary>
    public decimal[] Sums { get; set; }

    /// <summary>
    /// Массив элементов для операции произведения.
    /// </summary>
    public int[] Muls { get; set; }
  }
}
