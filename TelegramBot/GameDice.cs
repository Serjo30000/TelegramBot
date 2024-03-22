using System;

namespace TelegramBot
{
    public class GameDice : Games
    {
        private readonly Random Rnd1, Rnd2;
        private readonly int R1, R2;
        public GameDice()
        {
            Rnd1 = new Random();
            Rnd2 = new Random();
            R1 = Rnd1.Next(1, 7);
            R2 = Rnd1.Next(1, 7);
        }
        public Random Rnd11
        {
            get => Rnd1;
        }
        public Random Rnd22
        {
            get => Rnd2;
        }
        public int R11
        {
            get => R1;
        }
        public int R22
        {
            get => R2;
        }
        public override string Game()
        {
            string str = "";
            if (R1 == R2)
            {
                str += "Вы - " + R1 + " Бот - " + R2 + " у вас ничья";
                return str;
            }
            if (R1 > R2)
            {
                str += "Вы - " + R1 + " Бот - " + R2 + " вы победили";
                return str;
            }
            if (R1 < R2)
            {
                str += "Вы - " + R1 + " Бот - " + R2 + " вы проиграли";
                return str;
            }
            return "Вы ввели неправильное значение";
        }
    }
}
