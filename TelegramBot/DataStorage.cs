using System;
using System.Collections.Generic;
using System.Linq;
namespace TelegramBot
{
    public class DataStorage : Note
    {
        public DataStorage() : base()
        {

        }
        public override string AddNotes(string note)
        {
            List<string> _listP = ListR;
            if (note == null)
            {
                throw new Exception("Пустая строка");
            }
            _listP.Add(note);
            ListR = _listP;
            return ListR[ListR.Count - 1];
        }

        public override string RemoveNotes(int numb)
        {
            string str;
            List<string> _listP = ListR;
            if (numb < 0 || numb >= ListR.Count)
            {
                throw new Exception("Выход за пределы списка");
            }
            str = ListR[numb];
            _listP.RemoveAt(numb);
            ListR = _listP;
            return str + " -  заметка удалена";
        }

        public override bool RemoveHelper(string numb)
        {
            return base.RemoveHelper(numb);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < ListR.Count; i++)
            {
                str += "Заметка " + (i + 1) + " " + ListR[i] + "\n";
            }
            if (str == "")
            {
                return "Заметок нет";
            }
            else
            {
                return str;
            }
        }
    }
}
