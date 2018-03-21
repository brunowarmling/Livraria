using Livraria.Model.Entities;
using Livraria.Model.Logging;
using System;
using System.Web.Http;

namespace Livraria.Web.Controllers
{
    [Route("api/BookController")]
    public class BookController : ApiController, IRegisterController<Book, Controller.Controllers.BookController>
    {
        /// <summary>
        /// Gets <see cref="Controller.Controllers.BookController"/> object instance
        /// </summary>
        /// <returns>Returns <see cref="Controller.Controllers.BookController"/> object instance</returns>
        public Controller.Controllers.BookController GetController()
        {
            return new Controller.Controllers.BookController();
        }

        /// <summary>
        /// Inserts a new book
        /// </summary>
        /// <param name="instance"><see cref="Book"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/BookController/Insert")]
        public ResponseData Insert(Book book)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                var bookController = GetController();
                book.Code = 0;
                bookController.Insert(book);

                responseData.Sucess = true;
            }
            catch (Exception ex)
            {
                responseData.Sucess = false;
                responseData.ErrorMessage = ex.Message;

            }

            return responseData;
        }

        /// <summary>
        /// Updates a new book
        /// </summary>
        /// <param name="instance"><see cref="Book"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/BookController/Update")]
        public ResponseData Update(Book book)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                var bookController = GetController();
                bookController.Update(book);

                responseData.Sucess = true;
            }
            catch (Exception ex)
            {
                responseData.Sucess = false;
                responseData.ErrorMessage = ex.Message;

            }

            return responseData;
        }

        /// <summary>
        /// Deletes a new book
        /// </summary>
        /// <param name="instance"><see cref="Book"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/BookController/Delete")]
        public ResponseData Delete(Book book)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                var bookController = GetController();
                bookController.Delete(book);

                responseData.Sucess = true;
            }
            catch (Exception ex)
            {
                responseData.Sucess = false;
                responseData.ErrorMessage = ex.Message;

            }

            return responseData;
        }

        /// <summary>
        /// Returns a full list of books
        /// </summary>
        /// <param name="instance"><see cref="Book"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/BookController/Find")]
        public ResponseData Find(Book book)
        {
            Log.AddInfo($"Enter {Log.GetCurrentMethod()}");

            ResponseData responseData = new ResponseData();
            try
            {
                var bookController = GetController();
                var result = bookController.Select(book);

                responseData.Sucess = true;
                responseData.UserData = result;
            }
            catch (Exception ex)
            {
                responseData.Sucess = false;
                responseData.ErrorMessage = ex.Message;

            }

            return responseData;
        }

        /// <summary>
        /// Returns a book selected by id
        /// </summary>
        /// <param name="instance"><see cref="T"/> object instance</param>
        /// <returns>Returns <see cref="ResponseData"/> object instance</returns>
        [HttpPost, Route("api/BookController/Select")]
        public ResponseData Select(Book book)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                var bookController = GetController();
                var result = bookController.GetById(book.Code.Value);

                responseData.Sucess = true;
                responseData.UserData = result;
            }
            catch (Exception ex)
            {
                responseData.Sucess = false;
                responseData.ErrorMessage = ex.Message;

            }

            return responseData;
        }
    }
}