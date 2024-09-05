using Telegram.Bot.Types;

namespace FishSeller.Bot.Commands
{
    public interface IListener
    {
        public IListener? Receiver { get; set; }
        public IListener? Parent { get; set; }

        public void StopResend();
        public Task GetUpdate(Update update);
    }
}
