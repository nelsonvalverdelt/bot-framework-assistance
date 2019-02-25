using BumblebeeRobot.Helpers;
using BumblebeeRobot.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Services
{
 
    public class UsersService: Controller
    {
        public Usuario Auth(Cuenta cuenta)
        {
            var users = new List<Usuario>()
            {
                new Usuario()
                {
                    Id = 1,
                    Nombre = "Nelson",
                    Apellido = "Valverde La Torre",
                    Celular = "789458458",
                    Codigo = "000104374",
                    Contrasena = "123456",
                    Dni = "70671592",
                    Telefono = "435811"
                },
                new Usuario()
                {
                    Id = 2,
                    Nombre = "Cristian",
                    Apellido = "Mendoza Valverde",
                    Celular = "789584595",
                    Codigo = "00104375",
                    Contrasena = "789456",
                    Dni = "74471592",
                    Telefono = "5879876"
                }
            };

            var usuario = users.Where(u => u.Codigo == cuenta.Codigo && u.Contrasena == cuenta.Contrasena).FirstOrDefault();
            if(usuario != null)
            {
                StorageHelper.Set("usuario", usuario);
                return usuario;
            }
            else
            {
                StorageHelper.Clear();
                return null;
            }
           

        }
    }
}
