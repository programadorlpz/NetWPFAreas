using NetWPFAreasApp.DataAccess;
using NetWPFAreasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetWPFAreasApp.Services
{
    public class AuthenticationService
    {
        public AuthenticationService()
        {
        }

        public string Authenticate(string username, string password)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user?.Role;
            }
        }

        // Método para agregar usuarios
        public void AddUser(User newUser)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                if (context.Users.Any(u => u.Username == newUser.Username))
                {
                    throw new Exception("El nombre de usuario ya existe.");
                }

                newUser.CreatedAt = DateTime.Now;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        // Método para actualizar usuarios
        public void UpdateUser(User updatedUser)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);
                if (user == null)
                {
                    throw new Exception("El usuario no existe.");
                }

                user.Email = updatedUser.Email;
                user.PhoneNumber = updatedUser.PhoneNumber;
                context.SaveChanges();
            }
        }

        // Método para obtener los últimos N usuarios
        public List<User> GetLastUsers(int count)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                return context.Users.OrderByDescending(u => u.CreatedAt).Take(count).ToList();
            }
        }
    }
}
