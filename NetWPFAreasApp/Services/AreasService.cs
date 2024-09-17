using NetWPFAreasApp.DataAccess;
using NetWPFAreasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetWPFAreasApp.Services
{
    public class AreasService
    {
        public AreasService()
        {
            // Asegurarse de que las áreas existen en la base de datos
            using (var context = new NetWPFAreasDbContext())
            {
                if (!context.Areas.Any())
                {
                    var areas = new List<Area>
                    {
                        new Area { Name = "Nomina" },
                        new Area { Name = "Facturacion" },
                        new Area { Name = "Servicio al Cliente" },
                        new Area { Name = "IT" }
                    };
                    context.Areas.AddRange(areas);
                    context.SaveChanges();
                }
            }
        }

        public List<Area> GetAllAreas()
        {
            using (var context = new NetWPFAreasDbContext())
            {
                return context.Areas.ToList();
            }
        }

        public void AssignUserToArea(string username, string areaName)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                // Remover asignaciones existentes
                var existingAssignment = context.UserAreas.FirstOrDefault(ua => ua.Username == username);
                if (existingAssignment != null)
                {
                    context.UserAreas.Remove(existingAssignment);
                }

                // Asignar el usuario al área seleccionada
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                var area = context.Areas.FirstOrDefault(a => a.Name == areaName);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                if (area == null)
                {
                    throw new Exception("Área no encontrada.");
                }

                var userArea = new UserArea
                {
                    Username = username,
                    AreaName = areaName
                };

                context.UserAreas.Add(userArea);
                context.SaveChanges();
            }
        }

        public string GetUserArea(string username)
        {
            using (var context = new NetWPFAreasDbContext())
            {
                var userArea = context.UserAreas.FirstOrDefault(ua => ua.Username == username);
                return userArea?.AreaName;
            }
        }
    }
}
