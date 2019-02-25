using System;
using System.Threading;
using System.Threading.Tasks;
using BumblebeeRobot.Dialogs;
using BumblebeeRobot.Dialogs.Admision;
using BumblebeeRobot.Dialogs.Admision.Servicios;
using BumblebeeRobot.Dialogs.CampusUniversidad;
using BumblebeeRobot.Dialogs.Matricula;
using BumblebeeRobot.Dialogs.Matricula.Servicios;
using BumblebeeRobot.Dialogs.Preguntas;
using BumblebeeRobot.Dialogs.Usuario;
using BumblebeeRobot.Helpers;
using BumblebeeRobot.Models;
using BumblebeeRobot.Services;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;

namespace BumblebeeRobot.Bots
{
    public class BummblebeeBot : IBot
    {
        private readonly DialogSet dialogs;
        private readonly IConfiguracionGlobal _configuracionGlobal;
        public string Uri { get; private set; }
        public BummblebeeBot(BotAccessors botAccessors, IConfiguracionGlobal configuracionGlobal)
        {
            var dialogState = botAccessors.DialogStateAccessor;
            _configuracionGlobal = configuracionGlobal ?? throw new ArgumentNullException(nameof(configuracionGlobal));

            //Resolver la URI
            Uri = _configuracionGlobal.GetAbsoluteUri().ToString();

            // compose dialogs
            dialogs = new DialogSet(dialogState);
            dialogs.Add(PrincipalDialog.Instance);
            dialogs.Add(PrincipalAlternativoDialog.Instance);
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

            //Preguntas
            dialogs.Add(PreguntasDialog.Instance);

            dialogs.Add(new ChoicePrompt("choicePrompt"));
            dialogs.Add(new TextPrompt("textPrompt"));
            dialogs.Add(new NumberPrompt<int>("numberPrompt"));


            BotAccessors = botAccessors;
        }

        public BotAccessors BotAccessors { get; }


        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {

            //EstadisticaController.GuardarPreguntaAbierta("Nuevo 2");

            //Sevicio de usuario
            var userService = new UsersService();

            //Autenticación
            var usuario = userService.Auth(new Models.Cuenta
            {
                Codigo = "000104374",
                Contrasena = "123456"
            });

 
            if (turnContext.Activity.Value != null)
            {
                await turnContext.SendActivityAsync(turnContext.Activity.Value.ToString());
                
            }
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                // initialize state if necessary
                var state = await BotAccessors.BumblebeeBotStateAccessor.GetAsync(turnContext, () => new BumblebeeBotState(), cancellationToken);
              
                turnContext.TurnState.Add("BotAccessors", BotAccessors);

                var dialogCtx = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                if (dialogCtx.ActiveDialog == null)
                {
                    if(usuario != null)
                    {
                        await dialogCtx.BeginDialogAsync(PrincipalDialog.Id, cancellationToken);
                    }
                    else
                    {
                        await dialogCtx.BeginDialogAsync(PrincipalAlternativoDialog.Id, cancellationToken);
                    }
                    
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