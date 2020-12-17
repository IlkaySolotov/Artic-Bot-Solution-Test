using System;
using Telegram.Bot;
using Test.Artic.Bot;
using Test.Artic.Global;
using Test.Artic.JsSettings;
using static Test.Artic.JsSettings.Deserialize;
using C = System.Console;

namespace Test.Artic.Modules.Help
{
    public class RadiatorClass
    {
        TestVariable teVar;
        Setting self;
        Deserialize json;
        public RadiatorClass(Start start)
        {
            teVar = start.teVar;
            self = start.set;
        }
        public void SwitchHelp(string content, ITelegramBotClient c)
        {
            if(teVar.cmdPrefix == null)
            {
                teVar.cmdPrefix = ".";
            }
            debug("Mah man this is da second switch in Text");
            if (content[0] == teVar.cmdPrefix.ToCharArray()[0])
            {
                switch (content.Replace(teVar.cmdPrefix, null))
                {
                    case "help": Help(c); break;
                    case "info": Info(c); break;
                    default: Flagger(); break;
                }
            }
        }

        //string[] text = teVar.messageText.Remove(teVar.cmdPrefix).Split(" ");

        void Flagger()
        {
                self.Join = false;
                self.Leave = false;
                self.ChangeTitle = false;
 
            string msg = teVar.messageText;
            if(msg.StartsWith($"{teVar.cmdPrefix}set"))
            {
                if(msg.Contains(" -j false"))
                {
                    self.Join = false;
                    json.serialize();
                }
                else if (msg.Contains(" -j true"))
                {
                    self.Join = true;
                    json.serialize();
                }
                else if(msg.Contains(" -l false"))
                {
                    self.Leave = false;
                    json.serialize();
                }
                else if(msg.Contains(" -l true"))
                {
                    self.Leave = true;
                    json.serialize();
                }
                else
                {

                }
            }
        }
        void Help(ITelegramBotClient c)
        {
            
        }
        async void Info(ITelegramBotClient c)
        {
            await c.SendTextMessageAsync
               (
                 teVar.chatId,
                   $" ChatID:          { teVar.chatId          } \n" +
                   $" ChatTitle:       { teVar.chatTitle       } \n" +
                   $" ChatFirstName:   { teVar.chatFirstName   } \n" +
                   $" ChatLastName:    { teVar.chatLastName    } \n" +
                   $" ChatUserName:    { teVar.chatUserName    } \n" +
                   $" ChatDescription: { teVar.chatDescription } \n" +
                   $" ChatInviteLink:  { teVar.chatInviteLink  } \n"
               )
            ; 
        }
        void As2(ITelegramBotClient c)
        {

        }
        void As3(ITelegramBotClient c)
        {

        }

        #region deb
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
        #endregion
    }
}
