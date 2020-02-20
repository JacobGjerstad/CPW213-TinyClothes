using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothes.Models
{
    public static class SessionHelper
    {
        private const string IdKey = "Id";
        private const string UsernameKey = "Username";

        public static void CreateUserSession(int id, string username, IHttpContextAccessor http)
        {
            http.HttpContext.Session.SetInt32(key: IdKey, value: id);
            http.HttpContext.Session.SetString(key: UsernameKey, value: username);
        }

        /// <summary>
        /// Returns true if the user is logged in
        /// </summary>
        public static bool IsUserLoggedIn(IHttpContextAccessor http)
        {
            if (http.HttpContext.Session.GetInt32(IdKey).HasValue)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Logs user out and clears their session
        /// </summary>
        public static void DestroyUserSession(IHttpContextAccessor http)
        {
            http.HttpContext.Session.Clear();
        }
    }
}
