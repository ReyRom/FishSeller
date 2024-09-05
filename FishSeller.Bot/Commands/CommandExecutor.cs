using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FishSeller.Bot.Commands
{
    public class CommandExecutor: IListener
    {
        static CommandExecutor? executor;
        public static CommandExecutor Executor { get=> executor ??= new CommandExecutor(); }

        public Dictionary<string, ICommand> Commands { get; set; } = new Dictionary<string, ICommand>() 
        { 
            //{"/start", new StartCommand() }
        };
        public IListener? Receiver { get; set; }
        public IListener? Parent { get; set; }

        public async Task GetUpdate(Update update) 
        {
            if (Receiver != null)
            {
                await Receiver.GetUpdate(update);
            }
            else
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        if (update.Message?.Type == MessageType.Text)
                        {
                            await HandleCommand(update.Message.Text, update);
                        }
                        break;
                    case UpdateType.CallbackQuery:
                        await HandleCommand(update.CallbackQuery.Data, update);
                        break;
                    default:
                        break;
                }
            }
        }

        public async Task HandleCommand(string command, Update update)
        {
            if (Commands.ContainsKey(command))
            {
                if (Commands[command] is IListener listener)
                {
                    listener.Parent = this;
                    Receiver = listener;
                }
                await Commands[command].Execute(update);
            }
        }

        public void StopResend()
        {
            Receiver = null;
        }
    }
}
