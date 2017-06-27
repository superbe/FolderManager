using System;

namespace WebFolderManager.Core
{
    /// <summary>
    /// Данные последнего найденного документа.
    /// </summary>
    public class DocumentFoundEventArgs : EventArgs
    {
        /// <summary>
        /// Сведения о последнем найденном документе.
        /// </summary>
        public SearchResult Result { get; set; }
    }
}