using demo7dialogs.Dialogs.Matricula.Servicios;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo7dialogs.Dialogs.Matricula
{
    public class MatriculaDialog : WaterfallDialog
    {
        public MatriculaDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
               
                return await stepContext.PromptAsync("choicePrompt",
                new PromptOptions
                {
                    Prompt = stepContext.Context.Activity.CreateReply("🤖 Bumblebee: Tengo estas opciones para tí"),
                    Choices = new[] { new Choice { Value = "Mi Matricula" }, new Choice { Value = "Informacion" }, new Choice { Value = "Realizar un pago" } }.ToList()
                });

                //Choices = new[] { new Choice { Value = "Admision" }, new Choice { Value = "Matricula" }, new Choice { Value = "Inicio de clases" } }.ToList()
            });


            AddStep(async (stepContext, cancellationToken) =>
            {
                
                    var result = (stepContext.Result as ValueType);
                    var response = (stepContext.Result as FoundChoice)?.Value;

                    if (response == "Mi Matricula")
                    {
                        return await stepContext.BeginDialogAsync(MiMatriculaServiceDialog.Id);
                    }
                    if (response == "Informacion")
                    {
                        return await stepContext.BeginDialogAsync(InformacionMatriculaServiceDialog.Id);
                    }
                    if (response == "Quiero realizar un pago")
                    {
                        return await stepContext.BeginDialogAsync(PagoMatriculaServiceDialog.Id);
                    }

                return await stepContext.NextAsync();

            });

         
        }
        public new static string Id => "matriculaDialog";

        public static MatriculaDialog Instance { get; } = new MatriculaDialog(Id);
    }
}
