using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs
{
    public class PrincipalAlternativoDialog : WaterfallDialog
    {
        public PrincipalAlternativoDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"🤖: ¡Hola y Bienvenido!.\n Mi nombre es Bumblebee. ¿En qué te puedo ayudar?"),
                        Choices = new[] { new Choice { Value = "Examen Admision" }, new Choice { Value = "Matricula" }, new Choice { Value = "Sobre Carreras" }, new Choice { Value = "Realizar Pago" }, new Choice { Value = "Inscripcion Online"} }
                    });
            });
            AddStep(async (stepContext, cancellationToken) => { return await stepContext.ReplaceDialogAsync(Id); });
        }
        public new static string Id => "principalAlternativoDialog";

        public static PrincipalAlternativoDialog Instance { get; } = new PrincipalAlternativoDialog(Id);
    }
}
