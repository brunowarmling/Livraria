
namespace Livraria.Model.Interfaces
{
    /// <summary>
    /// Represents a table object
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// Primary key column of table
        /// </summary>
        int? Code { get; set; }

        /// <summary>
        /// Description column of table
        /// </summary>
        string Name { get; set; }
    }
}
