/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

using Test.Artic.Global;
using Test.Artic.JsSettings;
using Test.Artic.Modules.Help;

using C = System.Console;

namespace Test.Artic.Bot
{
    public class Start
    {
        // Variabili globali
        #region globals
        public TestVariable var;
        HelpClass help = new HelpClass();
        public Deserialize json;
        ITelegramBotClient _client;
        #endregion
        // Variabile booleana per iniziare e smettere di ricevere informazioni
        #region listen
        public Start(ITelegramBotClient client)
        {
            // this is correct
            var = new TestVariable();
            json = new Deserialize(this);
            debug("Im inside Start class");
            _client = client;
            client.OnMessage += OnMessage;
            success("Exiting Start class");
        }
        public void listen(bool status)
        {
            if (status == true)
            {
                debug("StartReceiving");
                _client.StartReceiving();
                success("Receiving");
            }
            else _client.StopReceiving(); 
        }

        // move it here?
        #endregion
        // Client TelegramBotClient
        // I Hvae literally no idea how to fix this
        // Just 1 sec
        #region client
        // right

        #endregion
        // Metodi generali ed eventi
        #region methods
        // no?
        private void OnMessage(object sender, MessageEventArgs messageEventArgs) {
            debug("Setting bunch of variables");
            // Variables 
            var. messageText     = messageEventArgs . Message . Text;
            long sex = messageEventArgs.Message.Chat.Id;
            var.chatId = sex;
          
            //var. chatId          = messageEventArgs . Message . Chat . Id;
            var. chatTitle       = messageEventArgs . Message . Chat . Title;
            var. chatPhoto       = messageEventArgs . Message . Chat . Photo;
            var. chatUserName    = messageEventArgs . Message . Chat . Username;
            var. chatLastName    = messageEventArgs . Message . Chat . LastName;
            var. chatFirstName   = messageEventArgs . Message . Chat . FirstName;
            var. chatInviteLink  = messageEventArgs . Message . Chat . InviteLink;
            var. chatDescription = messageEventArgs . Message . Chat . Description;
            var message          = messageEventArgs . Message;
            string[] text = var.messageText.Remove(var.cmdPrefix).Split(" ");
            success("Variables set!");
            C.WriteLine(var.chatId); // <= here it works
            debug("Configuring from JSON");
            readJSON();
            // ??
            // Temporarely useless, will be needed to call proper methods, will be used later
            debug("This is a switch man, calling somthin i guess");
            switch (message.Type)
            {
                default                              : /**/ break;
                case MessageType.Text                : help.SwitchHelp(var.messageText, _client); /**/ break;
                 case MessageType.ChatMemberLeft     : /**/ break;
                  case MessageType.ChatTitleChanged  : /**/ break;
                   case MessageType.ChatMembersAdded : /**/ break;
            }
        }
        // exactly
        void readJSON()
        {
            //json.deserialize(_client);
            json.serialize();
            //Thanks god
        }
        #endregion
        void debug(string cause)
        {
            C.ForegroundColor = System.ConsoleColor.Yellow;
            C.WriteLine("[!] " + cause);
            C.ForegroundColor = System.ConsoleColor.White;
        }
        void success(string cause)
        {
            C.ForegroundColor = System.ConsoleColor.Green;
            C.WriteLine("[+] " + cause);
            C.ForegroundColor = System.ConsoleColor.White;
        }
    }
}
