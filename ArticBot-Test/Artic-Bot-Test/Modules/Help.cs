using System;
using Telegram.Bot;
using Test.Artic.Global;

using C = System.Console;

namespace Test.Artic.Modules.Help
{
    class HelpClass
    {
        TestVariable var = new TestVariable();
        public void SwitchHelp(string content, ITelegramBotClient c)
        {
            debug("Mah man this is da second switch in Text");
            switch (content)
            {
                case ".help": Help(c); break;
            }
        }
        async void Help(ITelegramBotClient c)
        {
 
        }
        void debug(string cause)
        {
            C.ForegroundColor = ConsoleColor.Yellow;
            C.WriteLine("[!] " + cause);
            C.ForegroundColor = ConsoleColor.White;
        }
        void success(string cause)
        {
            C.ForegroundColor = ConsoleColor.Green;
            C.WriteLine("[+] " + cause);
            C.ForegroundColor = ConsoleColor.White;
        }
        void critical(string cause)
        {
            C.ForegroundColor = ConsoleColor.Red;
            C.WriteLine("[-] " + cause);
            C.ForegroundColor = ConsoleColor.White;
        }
    }
}
