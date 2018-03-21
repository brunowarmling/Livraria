using Livraria.Controller;
using Livraria.Model.Interfaces;
using System.Web.Http;

namespace Livraria.Web.Controllers
{
    /// <summary>
    /// Defines the contract to be an register controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T1"></typeparam>
    public interface IRegisterController<T, T1> where T : class, ITable where T1 : Controller<T>
    {
        /// <summary>
        /// Gets <see cref="T1" /> object instance
        /// </summary>
        /// <returns>Returns <see cref="T1" /> object instance</returns>
        T1 GetController();

        /// <summary>
        /// Handles the insert user event
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/{controller}/Insert")]
        ResponseData Insert(T instance);

        /// <summary>
        /// Handles the update user event
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/{controller}/Update")]
        ResponseData Update(T instance);

        /// <summary>
        /// Handles the delete user event
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/{controller}/Delete")]
        ResponseData Delete(T instance);

        /// <summary>
        /// Handles the find user event
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/{controller}/Find")]
        ResponseData Find(T instance);

        /// <summary>
        /// Handles the select user event
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/{controller}/Select")]
        ResponseData Select(T instance);
    }
}
