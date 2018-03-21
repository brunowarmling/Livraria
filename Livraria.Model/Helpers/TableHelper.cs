using Livraria.Model.Attributes;
using Livraria.Model.Interfaces;
using System.Reflection;

namespace Livraria.Model
{
    /// <summary>
    /// The purpose of this class is to provide extended methods to <see cref="Itable"/> objects
    /// </summary>
    public static class TableHelper
    {
        /// <summary>
        /// Returns the <see cref="ColumnNameAttribute"/> value
        /// </summary>
        /// <param name="table">Instance of object</param>
        /// <param name="propertyName">Property to extract the value</param>
        /// <returns></returns>
        public static string GetColumnName(this ITable table, string propertyName)
        {
            string result = string.Empty;
            PropertyInfo prop = table.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            var attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                ColumnNameAttribute authAttr = attr as ColumnNameAttribute;
                if (authAttr != null)
                {
                    result = authAttr.Name;
                }
            }

            return result;
        }
    }
}
