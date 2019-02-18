using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Matricula.Servicios
{
    public class MiMatriculaServiceDialog : WaterfallDialog
    {
        public MiMatriculaServiceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("textPrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("Cuál es tu ID de usuario?")
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result.ToString();

                if (response == "000104374")
                {
                    return await stepContext.PromptAsync("choicePrompt",
                   new PromptOptions
                   {
                       Prompt = stepContext.Context.Activity.CreateReply("Bienvenido Nelson")
                   });

                }
                else
                {
                   await stepContext.PromptAsync("textPrompt",
                   new PromptOptions
                   {
                       Prompt = stepContext.Context.Activity.CreateReply("No eres un usuario")
                   });

                    return await stepContext.BeginDialogAsync(Id);
                }

            });


        }

        public new static string Id => "miMatriculaServiceDialog";

        public static MiMatriculaServiceDialog Instance { get; } = new MiMatriculaServiceDialog(Id);
    }
}
