namespace TelegramBot
{
    public abstract class Games : Gameable
    {
        public Games()
        {

        }
        public virtual string Game()
        {
            return "Игра.";
        }
    }
}
