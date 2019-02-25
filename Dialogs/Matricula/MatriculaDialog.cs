using BumblebeeRobot.Dialogs.Matricula.Servicios;
using BumblebeeRobot.Dialogs.Preguntas;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs.Matricula
{
    public class MatriculaDialog : WaterfallDialog
    {
        public MatriculaDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {

                return await stepContext.BeginDialogAsync(PreguntasDialog.Id);

            });




         
        }
        public new static string Id => "matriculaDialog";

        public static MatriculaDialog Instance { get; } = new MatriculaDialog(Id);
    }
}
