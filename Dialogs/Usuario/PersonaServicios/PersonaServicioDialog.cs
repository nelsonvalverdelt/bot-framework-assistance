using demo7dialogs.Dialogs.Admision;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Usuario.PersonaServicios
{
    public class PersonaServicioDialog : WaterfallDialog
    {
        public PersonaServicioDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("¿Qué servicio necesitas saber?"),
                        Choices = new[] { new Choice { Value = "Admision" }, new Choice { Value = "Matricula" }, new Choice { Value = "Inicio de clases" } }.ToList()
                    });
            });

           
            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;

                if (response.Value == "Admision")
                {
                    return await stepContext.BeginDialogAsync(AdmisionDialog.Id);
                }
                
                if (response.Value == "Matricula")
                {
                    return await stepContext.BeginDialogAsync("");
                }
                if (response.Value == "Inicio de clases")
                {
                    return await stepContext.BeginDialogAsync("");
                }
                return await stepContext.NextAsync();
            });

            
        }
        public new static string Id => "personServiceDialog";
        public static PersonaServicioDialog Instance { get; } = new PersonaServicioDialog(Id);
    }
}
