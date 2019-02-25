using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs.Preguntas
{
    public class SugerenciaDialog : WaterfallDialog
    {
        public SugerenciaDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
        }
    }
}
