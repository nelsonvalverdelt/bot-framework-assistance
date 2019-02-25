using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BumblebeeRobot.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BumblebeeRobot.Services
{
    public class EstadisticaController
    {

        public async static Task GuardarPreguntaAbierta(string respuesta)
        {
            var lista = await LeerPreguntaAbierta();
            var respuestas = lista.Respuestas;
            respuestas.Add(respuesta);
            await GuardarJson("./Services/Data/PreguntaAbierta.json", lista);

        }
        public async static Task GuardarPreguntaEleccionUnica(string respuesta)
        {
            var lista = await LeerPreguntaEleccionUnica();
            var respuestas = lista.Respuestas;
            respuestas.Add(respuesta);
            await GuardarJson("./Services/Data/PreguntaEleccionUnica.json", lista);

        }
        public async static Task<PreguntaAbierta> LeerPreguntaAbierta()
        {
            var result = await LeerJson<PreguntaAbierta>("./Services/Data/PreguntaAbierta.json");
            return result;
        }

        public async static Task<PreguntaEleccionUnica> LeerPreguntaEleccionUnica()
        {
            var result = await LeerJson<PreguntaEleccionUnica>("./Services/Data/PreguntaEleccionUnica.json");
            return result;
        }

        #region Metodos privados
        private async static Task<TResult> LeerJson<TResult>(string filePath)
        {
            //Encoding.GetEncoding("iso-8859-1"): Lee caracteres especiales

            using (var r = new StreamReader(filePath, Encoding.GetEncoding("iso-8859-1")))
            {
                var readJson = await r.ReadToEndAsync();
                var result = JsonConvert.DeserializeObject<TResult>(readJson);
                return result;
            }

        }
        private async static Task GuardarJson<TObject>(string filePath, TObject data)
        {
            var json = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(filePath, json, Encoding.GetEncoding("iso-8859-1"));
        }
        #endregion Metodos privados
    }
}
