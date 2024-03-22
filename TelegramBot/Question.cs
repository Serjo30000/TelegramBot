using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public class Question
    {
        private readonly string questionText;
        private readonly string trueAnswer;
        
        public Question(string questionText, string trueAnswer)
        {
            this.questionText= questionText;
            this.trueAnswer= trueAnswer;
        }

        public string QuestionText
        {
            get
            {
                if (questionText == null)
                {
                    throw new Exception("Строка пустая");
                }
                return questionText;
            }
        }

        public string TrueAnswer
        {
            get
            {
                if (trueAnswer == null)
                {
                    throw new Exception("Строка пустая");
                }
                return trueAnswer;
            }
        }

        public override string ToString()
        {
            return questionText;
        }
    }
}
