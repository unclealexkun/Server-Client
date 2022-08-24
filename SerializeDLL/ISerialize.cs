namespace SerializeLibrary
{
  /// <summary>
  /// Интерфейс для сериализации общих классов.
  /// </summary>
  interface ISerialize<T>
  {
    /// <summary>
    /// Дессериализуем строку к общему классу.
    /// </summary>
    /// <param name="str">Входная строка.</param>
    /// <returns>Общий класс.</returns>
    T DeSerialize(string str);

    /// <summary>
    /// Сериализуем общий класс к строке.
    /// </summary>
    /// <param name="output">Результат вычислений.</param>
    /// <returns>Сериализованная строка.</returns>
    string Serialize(T output);
  }
}
