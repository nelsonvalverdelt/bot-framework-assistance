using System.Collections.Generic;
using System.Linq;
using demo7dialogs.Dialogs.CampusUniversidad;
using demo7dialogs.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace demo7dialogs.Dialogs.Usuario
{
    public class MainDialog : WaterfallDialog
    {
        private static List<Campus> Campus { get; set; }

        public MainDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            Campus = new List<Campus>
            {
                new Campus
                {
                    Id = 1,
                    Nombre = "Campus Trujillo"
                },
                new Campus
                {
                    Id = 2,
                    Nombre = "Campus Piura"
                }
            };

            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("🤖: ¡Hola! Mi nombre es Bumblebee y hoy seré tu Guia.\n Selecciona el campus de tu preferencia"),
                        Choices = ChoiceFactory.ToChoices( Campus.Select( c => c.Nombre).ToList())
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = (stepContext.Result as FoundChoice)?.Value;

                if (response == "Campus Trujillo")
                {
                    return await stepContext.BeginDialogAsync(CampusTrujilloDialog.Id);
                }

                if (response == "Campus Piura")
                {
                    return await stepContext.BeginDialogAsync(CampusPiuraDialog.Id);
                }

                return await stepContext.NextAsync();
            });

            AddStep(async (stepContext, cancellationToken) => { return await stepContext.ReplaceDialogAsync(Id); });
        }


        public new static string Id => "mainDialog";

        public static MainDialog Instance { get; } = new MainDialog(Id);
    }
}