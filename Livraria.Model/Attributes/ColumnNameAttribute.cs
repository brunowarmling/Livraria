using System;

namespace Livraria.Model.Attributes
{
    /// <summary>
    /// The purpose of this attribute is to store information about column name/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ColumnNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}