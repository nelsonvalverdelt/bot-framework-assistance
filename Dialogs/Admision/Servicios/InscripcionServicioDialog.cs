using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Admision.Servicios
{
    public class InscripcionServicioDialog : WaterfallDialog
    {
        public InscripcionServicioDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {

                return await stepContext.PromptAsync("textPrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("La fecha de inscripción es el Lunes 24 de junio del 2019"),

                    });
            });
        }
        public new static string Id => "inscripcionServiceDialog";
        public static InscripcionServicioDialog Instance { get; } = new InscripcionServicioDialog(Id);
    }
}
