using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Usuario
{
    public class EstudianteDialog : WaterfallDialog
    {
        public EstudianteDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
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

                if(response == "000104374")
                {
                    return await stepContext.PromptAsync("choicePrompt",
                   new PromptOptions
                   {
                       Prompt = stepContext.Context.Activity.CreateReply("Bienvenido Nelson")
                   });
                   
                }
                else
                {
                    return await stepContext.PromptAsync("choicePrompt",
                   new PromptOptions
                   {
                       Prompt = stepContext.Context.Activity.CreateReply("No eres un usuario")
                   });
                }
                
            });
        }
        public new static string Id => "studentDialog";
        public static EstudianteDialog Instance { get; } = new EstudianteDialog(Id);
    }
}
