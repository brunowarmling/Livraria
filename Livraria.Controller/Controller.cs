using Livraria.Model;
using Livraria.Model.Exceptions;
using Livraria.Model.Interfaces;
using Livraria.Model.Logging;
using Livraria.Model.SessionFactories;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Livraria.Controller
{
    /// <summary>
    /// The purpose of this class is provide a way to interact with <see cref="ITable"/> objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Controller<T> : IController<T> where T : class, ITable
    {
        #region Private Methods

        private ICriteria BuildCriteria(ISession session, T filter)
        {
            var criteria = session.CreateCriteria<T>();
            var properties = typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(filter);
                string columnName = filter.GetColumnName(prop.Name);
                if (value != null)
                {
                    if (value.GetType() == typeof(int) ||
                        value.GetType() == typeof(long) ||
                        value.GetType() == typeof(decimal))
                    {
                        criteria.Add(new NHibernate.Criterion.SimpleExpression(prop.Name, value, "="));
                    }
                    else
                    {
                        criteria.Add(new NHibernate.Criterion.LikeExpression(prop.Name, value.ToString(), NHibernate.Criterion.MatchMode.Anywhere));
                    }
                }
            }
            return criteria;
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Inserts a new row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        public virtual void Insert(T instance)
        {
            try
            {
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        session.Save(instance);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AddInfo(instance);
                throw new CustomApplicationException($"Error inserting { instance }. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        /// <summary>
        /// Deletes a row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        public virtual void Delete(T instance)
        {
            try
            {
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    T retrievedObject = session.Get<T>(instance.Code);

                    using (var trans = session.BeginTransaction())
                    {
                        session.Delete(retrievedObject);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AddInfo(instance);
                throw new CustomApplicationException($"Error removing { instance }. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        /// <summary>
        /// Updates a row on database
        /// </summary>
        /// <param name="instance"><see cref="ITable"/> object instance</param>
        public virtual void Update(T instance)
        {
            try
            {
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        session.Update(instance);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AddInfo(instance);
                throw new CustomApplicationException($"Error updating { instance }. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        /// <summary>
        /// Returns a full select on database
        /// </summary>
        /// <returns><see cref="IList<T>"/> object instance</returns>
        public virtual IList<T> Select()
        {
            return Select(null);
        }

        /// <summary>
        /// Returns a filtered select on database
        /// </summary>
        /// <returns><see cref="IList<T>"/> object instance</returns>
        public virtual IList<T> Select(T filter)
        {
            try
            {
                IList<T> instances;
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    var query = session.QueryOver<T>().OrderBy(x => x.Name).Asc;

                    if (filter != null)
                    {
                        instances = BuildCriteria(session, filter).AddOrder(Order.Asc("Name")).List<T>();
                    }
                    else
                    {
                        instances = query.List();
                    }

                    return instances;
                }
            }
            catch (Exception ex)
            {
                throw new CustomApplicationException($"Error retrieving objects. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        /// <summary>
        /// Returns a row filtered by id
        /// </summary>
        /// <param name="id">Id that will be filtered</param>
        /// <returns>An <see cref="ITable"/> object instance</returns>
        public virtual T GetById(int code)
        {
            try
            {
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    T instance = session.Get<T>(code);
                    return instance;
                }
            }
            catch (Exception ex)
            {
                throw new CustomApplicationException($"Error retrieving object by code: { code }. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        /// <summary>
        /// Returns a row filtered by name
        /// </summary>
        /// <param name="name">Name that will be filtered</param>
        /// <returns>An <see cref="ITable"/> object instance</returns>
        public virtual IList<T> GetByName(string name)
        {
            try
            {
                using (var session = MySQLSessionFactory.OpenSession())
                {
                    return session.QueryOver<T>().Where(c => c.Name == name).List();
                }
            }
            catch (Exception ex)
            {
                throw new CustomApplicationException($"Error retrieving object by name: { name }. Method: { Log.GetCurrentMethod() }", ex);
            }
        }

        #endregion Public Methods
    }
}
