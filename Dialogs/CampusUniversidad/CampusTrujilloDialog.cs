using demo7dialogs.Dialogs.Matricula;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.CampusUniversidad
{
    public class CampusTrujilloDialog : WaterfallDialog
    {
        public CampusTrujilloDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("🤖 Bumblebee: Bienvenido al Campus de Trujillo. \n Selecciona uno de nuestros servicios 👍🏼"),
                        Choices = new[] { new Choice { Value = "Admision" }, new Choice { Value = "Matricula" }, new Choice { Value = "Inicio de clases" } }.ToList()
                    });

            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = (stepContext.Result as FoundChoice)?.Value;

                if (response == "Admision")
                {
                    return await stepContext.BeginDialogAsync(CampusTrujilloDialog.Id);
                }

                if (response == "Matricula")
                {
                    return await stepContext.BeginDialogAsync(MatriculaDialog.Id);
                }

                if (response == "Inicio de clases")
                {
                    return await stepContext.BeginDialogAsync(CampusPiuraDialog.Id);
                }
                return await stepContext.NextAsync();
            });
        }


        public new static string Id => "campusTrujilloDialog";

        public static CampusTrujilloDialog Instance { get; } = new CampusTrujilloDialog(Id);
    }
}
