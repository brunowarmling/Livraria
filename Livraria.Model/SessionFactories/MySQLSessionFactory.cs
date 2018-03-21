using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Livraria.Model.Mappings;
using NHibernate;
using System.Configuration;

namespace Livraria.Model.SessionFactories
{
    /// <summary>
    /// The purpose of this class is to provide a <see cref="ISession"/> instance
    /// </summary>
    public class MySQLSessionFactory
    {
        #region Private Properties

        private static ISessionFactory _sessionFactory;
        private static string ConnectionString = "Server=localhost;Port=3306;Database=livraria;Uid=root;Pwd=root;";

        /// <summary>
        /// Instantiates when needed and returns an <see cref="ISessionFactory"/> object
        /// </summary>
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    IPersistenceConfigurer dbConfig = MySQLConfiguration.Standard.ConnectionString(ConnectionString);
                    var mapConfig = Fluently.Configure().Database(dbConfig).Mappings(c => c.FluentMappings.AddFromAssemblyOf<BookMap>());
                    _sessionFactory = mapConfig.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        #endregion Private Properties

        #region Public Static Methods

        /// <summary>
        ///  Create a database connection and open a NHibernate.ISession on it
        /// </summary>
        /// <returns>Returns an <see cref="ISession"/> object instance</returns>
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion Public Static Methods
    }
}
