using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Admision.Servicios
{
    public class ExamenServicioDialog : WaterfallDialog
    {
        public ExamenServicioDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                
                return await stepContext.PromptAsync("textPrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("El examen programado es:  Lunes 24 de junio del 2019"),
                 
                    });
            });
        }
        public new static string Id => "examenServiceDialog";
        public static ExamenServicioDialog Instance { get; } = new ExamenServicioDialog(Id);
    }
}
