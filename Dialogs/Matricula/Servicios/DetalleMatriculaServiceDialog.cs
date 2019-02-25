using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs.Matricula.Servicios
{
    public class DetalleMatriculaServiceDialog : WaterfallDialog
    {
        public DetalleMatriculaServiceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
        }

        public new static string Id => "detalleMatriculaServiceDialog";

        public static DetalleMatriculaServiceDialog Instance { get; } = new DetalleMatriculaServiceDialog(Id);
    }
}
