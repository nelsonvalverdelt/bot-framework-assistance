using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Admision.Servicios
{
    public class ResultadoServicioDialog : WaterfallDialog
    {
        public ResultadoServicioDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {

                return await stepContext.PromptAsync("textPrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("El resultado del examen está publicado es: https://wwww.upao.edu.pe"),

                    });
            });
        }
        public new static string Id => "resultadoServiceDialog";
        public static ResultadoServicioDialog Instance { get; } = new ResultadoServicioDialog(Id);
    }
}
