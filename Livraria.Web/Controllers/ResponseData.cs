using System;

namespace Livraria.Web.Controllers
{
    public class ResponseData
    {
        public bool Sucess;
        public String ErrorMessage;
        public Object UserData;

        public ResponseData()
        {
            Sucess = false;
            ErrorMessage = string.Empty;
            UserData = null;
        }
    }
}