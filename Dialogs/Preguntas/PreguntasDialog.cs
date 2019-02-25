using BumblebeeRobot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs.Preguntas
{
    public class PreguntasDialog : WaterfallDialog
    {
        public PreguntasDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("🤖: ¿Te parece útil utilizar a Bumblebee?"),
                        Choices = new[] { new Choice { Value = "Si" }, new Choice { Value = "No" }, new Choice { Value = "Dar Sugerencia" }}
                    });
            });


            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;

                if (response.Value == "Si")
                {
                    await EstadisticaController.GuardarPreguntaEleccionUnica("Sí");
                    return await stepContext.NextAsync();
                }

                if (response.Value == "No")
                {
                    await EstadisticaController.GuardarPreguntaEleccionUnica("No");
                    return await stepContext.NextAsync();
                }
                if (response.Value == "Dar Sugerencia")
                {
                    return await stepContext.NextAsync();
                }
                return await stepContext.NextAsync();
            });


        }

        public new static string Id => "preguntasDialog";

        public static PreguntasDialog Instance { get; } = new PreguntasDialog(Id);
    }
}
