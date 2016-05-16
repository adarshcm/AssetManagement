using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.DAL
{
    public class LoginRegDAL
    {
        public bool loginCheck(string email, string password)
        {
            bool status = false;
            if(email == "admin" && password == "admin")
            {
                status = true;
            }
            return status;
        }
    }
}