﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TinyClothes.Data;
using TinyClothes.Models;

namespace TinyClothes
{
    public static class AccountDb
    {
        public static async Task<bool> IsUsernameTaken(string username, StoreContext context)
        {
            bool isTaken = await(from a in context.Accounts
                               where username == a.Username
                               select a).AnyAsync();

            return isTaken;
        }

        public static async Task<Account> Register(StoreContext context, Account acc)
        {
            await context.Accounts.AddAsync(acc);
            await context.SaveChangesAsync();
            return acc;
        }

        /// <summary>
        /// Returns true if the username/email and password
        /// match a record in the database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<bool> DoesUserMatch(LoginViewModel login, StoreContext context)
        {
            bool doesMatch = await (from user in context.Accounts
            where (user.Email == login.UsernameOrEmail ||
                  user.Username == login.UsernameOrEmail) &&
                  user.Password == login.Password
            select user).AnyAsync();

            return doesMatch;
        }
    }
}