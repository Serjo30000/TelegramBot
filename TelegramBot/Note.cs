using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TelegramBot
{
    public abstract class Note : Noteable
    {
        private List<string> _listR;
        public Note()
        {
            _listR = new List<string>();
        }
        public List<string> ListR
        {
            get
            {
                if (_listR == null)
                {
                    throw new Exception("Список пустой");
                }
                return _listR.ToList();
            }
            set
            {
                _listR = value.ToList();
            }
        }
        public virtual string AddNotes(string note)
        {
            if (note == null)
            {
                throw new Exception("Пустая строка");
            }
            _listR.Add(note);
            return _listR[_listR.Count - 1];
        }
        public virtual string RemoveNotes(int numb)
        {
            string str;
            if (numb < 0 || numb >= _listR.Count)
            {
                throw new Exception("Выход за пределы списка");
            }
            str = _listR[numb];
            _listR.RemoveAt(numb);
            return str + " -  заметка удалена";
        }
        public virtual bool RemoveHelper(string numb)
        {
            for (int i = 0; i < numb.Length; i++)
            {
                if (numb[i] < '0' || numb[i] > '9')
                {
                    return false;
                }
            }
            if (_listR.Count <= 0)
            {
                return false;
            }
            return true;
        }


    }
}
