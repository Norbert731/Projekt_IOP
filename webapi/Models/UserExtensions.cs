using System;
using webapi.Models;

namespace webapi.Extensions
{
    public static class UserExtensions
    {
        public static void DoSomething(this User user, ContactsList contactsList)
        {
            // Implementacja metody rozszerzenia
            Console.WriteLine($"User: {user.Login}, ContactsList: {contactsList.FirstName} {contactsList.LastName}");
        }
    }
}
