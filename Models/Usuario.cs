using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Dni { get; set; }
        public string Codigo { get; set; }
        public string Contrasena { get; set; }
    }
    public class Cuenta
    {
        public string Codigo { get; set; }
        public string Contrasena { get; set; }
    }
}
