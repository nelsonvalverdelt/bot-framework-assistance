using AdaptiveCards;
using BumblebeeRobot.Cards;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Dialogs.Matricula.Servicios
{
    public class MiMatriculaServiceDialog : WaterfallDialog
    {
        public MiMatriculaServiceDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            //AddStep(async (stepContext, cancellationToken) =>
            //{
            //    var response = stepContext.Context.Activity.CreateReply("🤖 Bumblebee: Para realizar esta acción necesitamos tu información de Usuario. Ingresa tus credenciales");
            //    response.Attachments = new List<Attachment>() { CrearAutenticacionAdaptiveCard() };

            //    return await stepContext.PromptAsync("choicePrompt",
            //   new PromptOptions
            //   {
            //       Prompt = response
            //   });
            //});


            AddStep(async (stepContext, cancellationToken) =>
            {

                if (stepContext.Context.Activity.Value != null)
                {
                    await stepContext.Context.SendActivityAsync(stepContext.Context.Activity.Value.ToString());
                }
                return await stepContext.NextAsync();
            });

        }

        //private Attachment CrearAutenticacionAdaptiveCard()
        //{
        //    var card = new AdaptiveCard();
     
        //    card.Body.Add(new AdaptiveTextBlock() { Text = "ID: ", Size = AdaptiveTextSize.Medium, Weight = AdaptiveTextWeight.Bolder });
        //    card.Body.Add(new AdaptiveTextInput() { Style = AdaptiveTextInputStyle.Text, Id = "Id", IsRequired = true });
        //    card.Body.Add(new AdaptiveTextBlock() { Text = "Contraseña: ", Size = AdaptiveTextSize.Medium, Weight = AdaptiveTextWeight.Bolder });
        //    card.Body.Add(new AdaptiveTextInput() { Style = AdaptiveTextInputStyle.Text, Id = "Contrasena", IsRequired = true});
        //    card.Actions.Add(new AdaptiveSubmitAction() { Title = "Enviar" });
        //    return new Attachment()
        //    {
        //        ContentType = AdaptiveCard.ContentType,
        //        Content = card
        //    };

        //}
        public new static string Id => "miMatriculaServiceDialog";

        public static MiMatriculaServiceDialog Instance { get; } = new MiMatriculaServiceDialog(Id);
    }
}
