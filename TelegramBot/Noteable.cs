using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public interface Noteable
    {
        string AddNotes(string note);
        string RemoveNotes(int numb);
        bool RemoveHelper(string numb);
    }
}
