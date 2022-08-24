using System;

namespace CommonLibrary
{
  /// <summary>
  /// Выходные данные.
  /// </summary>
  [Serializable]
  public class Output
  {
    /// <summary>
    /// Сумма входных чисел.
    /// </summary>
    public decimal SumResult { get; set; }

    /// <summary>
    /// Произведение входных чисел.
    /// </summary>
    public int MulResult { get; set; }

    /// <summary>
    /// Отсортированный по возрастанию результат.
    /// </summary>
    public decimal[] SortedInputs { get; set; }
  }
}
