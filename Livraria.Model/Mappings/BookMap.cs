using FluentNHibernate.Mapping;
using Livraria.Model.Entities;

namespace Livraria.Model.Mappings
{
    /// <summary>
    /// The purpose of this class is to map the <see cref="Book"/> class to NHibernate
    /// </summary>
    public class BookMap : ClassMap<Book>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BookMap"/> class
        /// </summary>
        public BookMap()
        {
            Book book = new Book();

            Id(p => p.Code, book.GetColumnName("Code"));
            Map(p => p.Name, book.GetColumnName("Name"));
            Map(p => p.Author, book.GetColumnName("Author"));
            Table(Book.TableName);
        }
    }
}
