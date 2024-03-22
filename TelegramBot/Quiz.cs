using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TelegramBot
{
    public abstract class Quiz : Quizable
    {
        public List<Question> _questionList= new List<Question>();
        public Quiz(List<Question> _questionList)
        {
            this._questionList = _questionList;
        }

        public int isCount()
        {
            return _questionList.Count;
        }

        public virtual bool isAnswer(Question qw, string answ)
        {
            if (qw == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
