using Livraria.Controller.Controllers;
using Livraria.Model.Entities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Livraria.Controller.Test
{
    [Binding]
    public class BookSteps
    {
        BookController bookController = null;
        Book book = null;
        Exception exception = null;

        [BeforeScenario(Order = 10)]
        public void Initialize()
        {
            bookController = new BookController();
            book = new Book();

            switch (ScenarioContext.Current.ScenarioInfo.Title)
            {
                case "Edit a book":
                case "Delete a book":
                    if (bookController.Select().Count == 0)
                    {
                        bookController.Insert(new Book() { Code = 1, Name = "test", Author = "test" });
                    }
                    break;
                case "Select books by code":
                case "Select books by name":
                case "Select books by author":
                    if (bookController.Select().Count == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            bookController.Insert(new Book() { Code = (i + 1), Name = "test", Author = "test" });
                        }
                    }
                    break;
            }
        }

        [AfterScenario(Order = 10)]
        public void Clean()
        {
            BookController bookController = new BookController();
            foreach (var item in bookController.Select())
            {
                bookController.Delete(item);
            }
        }

        [Given(@"I have entered name '(.*)' into the book page")]
        public void GivenIHaveEnteredNameIntoTheBookPage(string name)
        {
            book.Name = name;
        }

        [Given(@"I have also entered author '(.*)' into book page")]
        public void GivenIHaveAlsoEnteredAuthorIntoBookPage(string author)
        {
            book.Author = author;
        }

        [Given(@"I have entered author '(.*)' into book page")]
        public void GivenIHaveEnteredAuthorIntoBookPage(string author)
        {
            book.Author = author;
        }


        [Given(@"I have entered id (.*) into the book page")]
        public void GivenIHaveEnteredIdIntoTheBookPage(int id)
        {
            book = new Book() { Code = id };
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            try
            {
                book.Code = 0;
                bookController.Insert(book);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"I press Save")]
        public void WhenIPressSave()
        {
            try
            {
                bookController.Update(book);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"I press Delete")]
        public void WhenIPressDelete()
        {
            try
            {
                bookController.Delete(book);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [When(@"I press Find")]
        public void WhenIPressFind()
        {
            try
            {
                var result = bookController.Select(book);
                if (result.Count == 0)
                {
                    throw new Exception("No data found");
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }


        [Then(@"the result should be success")]
        public void ThenTheResultShouldBeSuccess()
        {
            Assert.IsNull(exception);
        }
    }
}
