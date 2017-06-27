using System;

namespace WebFolderManager.Core
{
    /// <summary>
    /// Делегат события нахождения документа.
    /// </summary>
    /// <param name="sender">Элемент вызвавший обработчик.</param>
    /// <param name="e">Сведения о последнем найденном документе.</param>
    public delegate void DocumentFoundDelegate(Object sender, DocumentFoundEventArgs e);
}