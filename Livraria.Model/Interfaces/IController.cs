using System.Collections.Generic;

namespace Livraria.Model.Interfaces
{
    /// <summary>
    /// Interface for classes capable of intering to <see cref="ITable"/>
    /// </summary>
    /// <typeparam name="T"><see cref="ITable"/> object instance</typeparam>
    public interface IController<T> where T : ITable
    {
        /// <summary>
        /// Inserts a new row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        void Insert(T instance);

        /// <summary>
        /// Updates a row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        void Update(T instance);

        /// <summary>
        /// Deletes a row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        void Delete(T instance);

        /// <summary>
        /// Returns a full select on database
        /// </summary>
        /// <returns><see cref="IList<T>"/> object instance</returns>
        IList<T> Select();

        /// <summary>
        /// Returns a filtered select on database
        /// </summary>
        /// <returns><see cref="IList<T>"/> object instance</returns>
        IList<T> Select(T filter);

        /// <summary>
        /// Returns a row filtered by id
        /// </summary>
        /// <param name="id">Id that will be filtered</param>
        /// <returns>An <see cref="ITable"/> object instance</returns>
        T GetById(int id);

        /// <summary>
        /// Returns a row filtered by name
        /// </summary>
        /// <param name="name">Name that will be filtered</param>
        /// <returns>An <see cref="ITable"/> object instance</returns>
        IList<T> GetByName(string name);
    }
}
