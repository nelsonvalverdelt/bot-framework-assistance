using System;
using BumblebeeRobot.Bots;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace BumblebeeRobot
{
    public class BotAccessors
    {
        public BotAccessors(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }

        public static string BumblebeeBotStateAccessorName { get; } = $"{nameof(BotAccessors)}.BumblebeeBotState";
        public IStatePropertyAccessor<BumblebeeBotState> BumblebeeBotStateAccessor { get; internal set; }

        public static string DialogStateAccessorName { get; } = $"{nameof(BotAccessors)}.DialogState";
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; internal set; }
        public ConversationState ConversationState { get; }
    }
}