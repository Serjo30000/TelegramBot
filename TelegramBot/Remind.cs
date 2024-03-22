using System;
using System.Collections.Generic;
using System.Linq;

namespace TelegramBot
{
    public class Remind : Note
    {
        private List<string> _listI;
        private List<bool> _listF;
        public Remind() : base()
        {
            _listF = new List<bool>();
            _listI = new List<string>();
        }

        public List<string> ListI
        {
            get
            {
                if (_listI == null)
                {
                    throw new Exception("Список пустой");
                }
                return _listI.ToList();
            }
            set
            {
                _listI = value.ToList();
            }
        }
        public List<bool> ListF
        {
            get
            {
                if (_listF == null)
                {
                    throw new Exception("Список пустой");
                }
                return _listF.ToList();
            }
            set
            {
                _listF = value.ToList();
            }
        }
        public override string AddNotes(string note)
        {
            if (note == null)
            {
                throw new Exception("Пустая строка");
            }
            List<string> _listP = ListR;
            string str1 = "";
            string str2 = "";
            int kk1 = 0;
            int dd1 = 0;
            int mm1 = 0;
            int ss1 = 10;
            for (int i = 0; i < note.Length; i++)
            {
                if (note[i].Equals('.'))
                {
                    kk1++;
                }
                if (!note[i].Equals(' ') && note[i]>='0' && note[i]<='9' && kk1<1)
                {
                    dd1 += ((int)(note[i] - 48))*ss1;
                    if (ss1 == 1)
                    {
                        ss1 = 10;
                    }
                    else
                    {
                        ss1 =1;
                    }
                }
                else if (!note[i].Equals(' ') && note[i] >= '0' && note[i] <= '9' && kk1>=1 && kk1 < 2)
                {
                    mm1 += ((int)(note[i] - 48)) * ss1;
                    if (ss1 == 1)
                    {
                        ss1 = 10;
                    }
                    else
                    {
                        ss1 =1;
                    }
                }
                else if (!note[i].Equals('.'))
                {
                    str2 += note[i];
                }
            }
            if (mm1 > 1)
            {
                dd1 += 31;
            }
            if (mm1 > 2)
            {
                dd1 += 28;
            }
            if (mm1 > 3)
            {
                dd1 += 31;
            }
            if (mm1 > 4)
            {
                dd1 += 30;
            }
            if (mm1 > 5)
            {
                dd1 += 31;
            }
            if (mm1 > 6)
            {
                dd1 += 30;
            }
            if (mm1 > 7)
            {
                dd1 += 31;
            }
            if (mm1 > 8)
            {
                dd1 += 31;
            }
            if (mm1 > 9)
            {
                dd1 += 30;
            }
            if (mm1 > 10)
            {
                dd1 += 31;
            }
            if (mm1 > 11)
            {
                dd1 += 30;
            }
            str1 += dd1;
            _listP.Add(str2);
            ListR = _listP;
            _listI.Add(str1);
            _listF.Add(true);
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
            _listI.RemoveAt(numb);
            _listF.RemoveAt(numb);
            return str + " - напоминание удалено";
        }

        public override bool RemoveHelper(string numb)
        {
            return base.RemoveHelper(numb);
        }

        public string ToRemind(int t)
        {
            string str = ""+ t;
            string str1 = "";
            for (int i = 0; i < ListR.Count; i++)
            {
                if (str == _listI[i] && _listF[i]==true)
                {
                    _listF[i] = false;
                    str1 += "Напоминание " + (i +1) + " -" + ListR[i] + "\n";
                }
            }
            string str2=RemoveNotes(ListR.Count-1);
            return str1;
        }

        public Boolean RemindHelper(int t)
        {
            string str = "" + t;
            for (int i = 0; i < ListR.Count; i++)
            {
                if (str == _listI[i] && _listF[i] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < ListR.Count; i++)
            {
                str += "Напоминание " + (i + 1) + ListR[i] + "\n";
            }
            if (str == "")
            {
                return "Напоминаний нет";
            }
            else
            {
                return str;
            }
        }
    }
}
