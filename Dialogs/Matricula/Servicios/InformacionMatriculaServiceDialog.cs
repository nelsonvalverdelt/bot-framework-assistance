using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Matricula.Servicios
{
    public class InformacionMatriculaServiceDialog : WaterfallDialog
    {
        public InformacionMatriculaServiceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
        }

        public new static string Id => "informacionMatriculaServiceDialog";

        public static InformacionMatriculaServiceDialog Instance { get; } = new InformacionMatriculaServiceDialog(Id);
    }
}
