using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public interface Quizable
    {
        int isCount();

        bool isAnswer(Question qw, string answ);
    }
}
