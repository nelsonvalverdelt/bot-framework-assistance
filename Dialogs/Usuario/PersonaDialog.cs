
using demo7dialogs.Dialogs.Usuario.PersonaServicios;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Usuario
{
    public class PersonaDialog : WaterfallDialog
    {
        public PersonaDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.BeginDialogAsync(PersonaServicioDialog.Id);
            });
        }
        public new static string Id => "personDialog";
        public static PersonaDialog Instance { get; } = new PersonaDialog(Id);
    }
}
