using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Matricula.Servicios
{
    public class PagoMatriculaServiceDialog : WaterfallDialog
    {
        public PagoMatriculaServiceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
        }
        public new static string Id => "pagoMatriculaServiceDialog";

        public static PagoMatriculaServiceDialog Instance { get; } = new PagoMatriculaServiceDialog(Id);
    }

}
