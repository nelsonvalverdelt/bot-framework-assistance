using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Models
{
    public class PreguntaRespuesta
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
    }

    public class PreguntaAbierta: PreguntaRespuesta
    {
        public List<string> Respuestas { get; set; }
    }
    public class PreguntaEleccionUnica : PreguntaRespuesta
    {
        public List<string> Respuestas { get; set; }
    }
}
