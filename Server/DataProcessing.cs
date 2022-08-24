using System.Collections.Generic;
using System.Linq;
using CommonLibrary;

namespace SerializeLibrary
{
  /// <summary>
  /// Обработка данных.
  /// </summary>
  public class DataProcessing
  {
		#region Поля и свойства

    /// <summary>
    /// Результат для суммы.
    /// </summary>
		private decimal sumResult;

    /// <summary>
    /// Результат для произведения.
    /// </summary>
    private int mulResult;

    /// <summary>
    /// Сортировка введённых данных.
    /// </summary>
    private decimal[] sortedInputs;

    #endregion

    #region Методы

    /// <summary>
    /// Суммирование всех элементов с коэффицентом.
    /// </summary>
    /// <param name="input">Входной класс.</param>
    /// <returns>Сумма элементов с умножением на коэффицент.</returns>
    private decimal Sum(Input input)
    {
      sumResult = input.Sums.Sum() * input.K;
      return sumResult;
    }

    /// <summary>
    /// Умножение всех элементов.
    /// </summary>
    /// <param name="input">Входной класс.</param>
    /// <returns>Произведение всех элементов.</returns>
    private int Mul(Input input)
    {
      mulResult = input.Muls.Aggregate(1, (x, y) => x * y);
      return mulResult;
    }

    /// <summary>
    /// Сортировка всех элементов.
    /// </summary>
    /// <param name="input">Входной класс.</param>
    /// <returns>Отсортированные элементы.</returns>
    private decimal[] Sort(Input input)
    {
      List<decimal> list = new List<decimal>();
      list.AddRange(input.Sums);
      list.AddRange(input.Muls.Select(m => (decimal)m));
      list.Sort();
      sortedInputs = list.ToArray();
      return sortedInputs;
    }

    /// <summary>
    /// Результат выполения операций.
    /// </summary>
    /// <param name="input">Входной класс.</param>
    /// <returns>Выходной класс.</returns>
    public Output Result(Input input)
    {
      return new Output()
      {
        SumResult = this.Sum(input),
        MulResult = this.Mul(input),
        SortedInputs = this.Sort(input)
      };
    }

		#endregion
	}
}
