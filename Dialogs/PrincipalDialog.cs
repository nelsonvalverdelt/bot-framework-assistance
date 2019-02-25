using System;
using System.Collections.Generic;
using System.Linq;
using BumblebeeRobot.Dialogs.Admision.Servicios;
using BumblebeeRobot.Dialogs.CampusUniversidad;
using BumblebeeRobot.Dialogs.Matricula.Servicios;
using BumblebeeRobot.Dialogs.Preguntas;
using BumblebeeRobot.Helpers;
using BumblebeeRobot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace BumblebeeRobot.Dialogs.Usuario
{
    public class PrincipalDialog : WaterfallDialog
    {
     
        public PrincipalDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
         
            var usuario = StorageHelper.Get<Models.Usuario>("usuario");
            

            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"🤖: ¡Bienvenido {usuario.Nombre} {usuario.Apellido}.\n ¿En qué te puedo ayudar?"),
                        Choices = new[] { new Choice { Value = "Mi Matricula" },new Choice { Value = "Mis Cursos" }, new Choice { Value = "Realizar Pago" }, new Choice { Value = "Inscripción" }, new Choice { Value = "Otros" } }
                    });
            });


            //AddStep(async (stepContext, cancellationToken) => { return await stepContext.ReplaceDialogAsync(Id); });


            AddStep(async (stepContext, cancellationToken) =>
            {

                var response = (stepContext.Result as FoundChoice)?.Value;

                if (response == "Mi Matricula")
                {
                    return await stepContext.BeginDialogAsync(MiMatriculaServiceDialog.Id);
                }
                if (response == "Mis Cursos")
                {
                    return await stepContext.BeginDialogAsync(MiMatriculaServiceDialog.Id);
                }
                if (response == "Realizar Pago")
                {
                    return await stepContext.BeginDialogAsync(PagoMatriculaServiceDialog.Id);
                }
                if (response == "Inscripción")
                {
                    return await stepContext.BeginDialogAsync(InscripcionServicioDialog.Id);
                }
                if (response == "Otros")
                {
                    return await stepContext.BeginDialogAsync(PreguntasDialog.Id);
                }
                return await stepContext.NextAsync();

            });
        }



        public new static string Id => "mainDialog";

        public static PrincipalDialog Instance { get; } = new PrincipalDialog(Id);
    }
}