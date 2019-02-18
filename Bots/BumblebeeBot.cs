using System.Threading;
using System.Threading.Tasks;
using demo7dialogs.Dialogs.Admision;
using demo7dialogs.Dialogs.Admision.Servicios;
using demo7dialogs.Dialogs.CampusUniversidad;
using demo7dialogs.Dialogs.Matricula;
using demo7dialogs.Dialogs.Matricula.Servicios;
using demo7dialogs.Dialogs.Usuario;
using demo7dialogs.Dialogs.Usuario.PersonaServicios;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace demo7dialogs.Bots
{
    public class BummblebeeBot : IBot
    {
        private readonly DialogSet dialogs;

        public BummblebeeBot(BotAccessors botAccessors)
        {
            var dialogState = botAccessors.DialogStateAccessor;
            // compose dialogs
            dialogs = new DialogSet(dialogState);
            dialogs.Add(MainDialog.Instance);

            //Admision
            dialogs.Add(ExamenServicioDialog.Instance);
            dialogs.Add(InscripcionServicioDialog.Instance);
            dialogs.Add(ResultadoServicioDialog.Instance);
            dialogs.Add(AdmisionDialog.Instance);


            //Campus
            dialogs.Add(CampusPiuraDialog.Instance);
            dialogs.Add(CampusTrujilloDialog.Instance);

            //Matrícula
            dialogs.Add(MatriculaDialog.Instance);
            dialogs.Add(PagoMatriculaServiceDialog.Instance);
            dialogs.Add(InformacionMatriculaServiceDialog.Instance);
            dialogs.Add(MiMatriculaServiceDialog.Instance);

            dialogs.Add(EstudianteDialog.Instance);
            dialogs.Add(PersonaDialog.Instance);
            dialogs.Add(PersonaServicioDialog.Instance);
            dialogs.Add(new ChoicePrompt("choicePrompt"));
            dialogs.Add(new TextPrompt("textPrompt"));
            dialogs.Add(new NumberPrompt<int>("numberPrompt"));
            BotAccessors = botAccessors;
        }

        public BotAccessors BotAccessors { get; }


        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                // initialize state if necessary
                var state = await BotAccessors.BankingBotStateStateAccessor.GetAsync(turnContext, () => new BumblebeeBotState(), cancellationToken);

                turnContext.TurnState.Add("BotAccessors", BotAccessors);

                var dialogCtx = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                if (dialogCtx.ActiveDialog == null)
                {
                    await dialogCtx.BeginDialogAsync(MainDialog.Id, cancellationToken);
                }
                else
                {
                    await dialogCtx.ContinueDialogAsync(cancellationToken);
                }

                await BotAccessors.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            }
        }
    }
}