using CommonLibrary;

namespace Client
{
  /// <summary>
  /// Реализация клиента.
  /// </summary>
  interface IClient
  {
    /// <summary>
    /// Проверка доступности сервера.
    /// </summary>
    /// <returns>True - если сервер доступен, иначе Fasle.</returns>
    bool Ping();

    /// <summary>
    /// Получить входные данных.
    /// </summary>
    /// <returns>Входной класс.</returns>
    Input GetInputData();

    /// <summary>
    /// Записать ответ.
    /// </summary>
    /// <param name="output">Выходной класс.</param>
    /// <returns>True - если ответ записан, иначе - False.</returns>
    bool WriteAnswer(Output output);
  }
}
