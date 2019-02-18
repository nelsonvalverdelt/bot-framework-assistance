using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.CampusUniversidad
{
    public class CampusPiuraDialog : WaterfallDialog
    {
        public CampusPiuraDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {

            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("👦🏻 Hola!. Bienvenido al campus 🏢 Piura. Selecciona uno de nuestros servicios 👍🏼"),
                        Choices = new[] { new Choice { Value = "Admision" }, new Choice { Value = "Matricula" }, new Choice { Value = "Inicio de clases" } }.ToList()
                    });
            });
        }
        public new static string Id => "campusPiuraDialog";

        public static CampusPiuraDialog Instance { get; } = new CampusPiuraDialog(Id);
    }
}
