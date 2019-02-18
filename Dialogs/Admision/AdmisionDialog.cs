using demo7dialogs.Dialogs.Admision.Servicios;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Admision
{
    public class AdmisionDialog : WaterfallDialog
    {
        public AdmisionDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("¿Qué información necesidas del Examen de Admisión?"),
                        Choices = new[] { new Choice { Value = "Examen" }, new Choice { Value = "Inscripcion" }, new Choice { Value = "Resultado" } }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;

                if (response.Value == "Examen")
                {
                    return await stepContext.BeginDialogAsync(ExamenServicioDialog.Id);
                }

                if (response.Value == "Inscripcion")
                {
                    return await stepContext.BeginDialogAsync(InscripcionServicioDialog.Id);
                }
                if (response.Value == "Resultado")
                {
                    return await stepContext.BeginDialogAsync(ResultadoServicioDialog.Id);
                }
                return await stepContext.NextAsync();
            });
        }


        public new static string Id => "admisionDialog";
        public static AdmisionDialog Instance { get; } = new AdmisionDialog(Id);
    }
}
