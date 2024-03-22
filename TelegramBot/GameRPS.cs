using System;
using System.Collections.Generic;
using System.Linq;
namespace TelegramBot
{
    public class GameRPS : Games
    {
        private readonly string Txt1;
        private readonly List<string> listG1 = new List<string> { "камень", "ножницы", "бумага" };
        private readonly Random Rndd1;
        private readonly int Rr1;
        public GameRPS(string Txt1)
        {
            if (Txt1 == null)
            {
                throw new Exception("Вы ввели неправильное значение");
            }
            this.Txt1 = Txt1;
            Rndd1 = new Random();
            Rr1 = Rndd1.Next(0, 3);
        }
        public Random Rndd11
        {
            get => Rndd1;
        }
        public int Rr11
        {
            get => Rr1;
        }
        public string Txtt
        {
            get => Txt1;
        }
        public List<string> Lst
        {
            get => listG1.ToList();
        }
        public override string Game()
        {
            string str = "";
            
            if (Txt1 == listG1[Rr1])
            {
                str += listG1[Rr1] + " - у вас ничья";
                return str;
            }
            if ((Txt1 == "камень" && listG1[Rr1] == "ножницы") || (Txt1 == "бумага" && listG1[Rr1] == "камень") || (Txt1 == "ножницы" && listG1[Rr1] == "бумага"))
            {
                str += listG1[Rr1] + " - ты победил";
                return str;
            }
            if ((Txt1 == "камень" && listG1[Rr1] == "бумага") || (Txt1 == "бумага" && listG1[Rr1] == "ножницы") || (Txt1 == "ножницы" && listG1[Rr1] == "камень"))
            {
                str += listG1[Rr1] + " - ты проиграл";
                return str;
            }
            return "Вы ввели неправильное значение";
        }
    }
}
