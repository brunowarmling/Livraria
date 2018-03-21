using Livraria.Model.Attributes;
using Livraria.Model.Interfaces;

namespace Livraria.Model.Entities
{
    /// <summary>
    /// This class represents the table "Livros"
    /// </summary>
    public class Book : ITable
    {
        /// <summary>
        /// Gets the table name
        /// </summary>
        public const string TableName = "Livros";

        /// <summary>
        /// Gets or sets the code
        /// </summary>
        [ColumnName("codigo")]
        public virtual int? Code { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [ColumnName("nome")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the author
        /// </summary>
        [ColumnName("autor")]
        public virtual string Author { get; set; }
    }
}
