using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TelegramBot
{
    public class Victorina : Quiz
    {
        private int countTrueAnswer;
        public Victorina(List<Question> _questionList) : base(_questionList)
        {
            countTrueAnswer = 0;
        }

        public override bool isAnswer(Question qw,string answ)
        {
            if (qw.TrueAnswer== answ)
            {
                countTrueAnswer++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Вы ответили верно на " + countTrueAnswer + " вопросов из " + isCount() + ".";
        }
    }
}
