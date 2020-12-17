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
using static Test.Artic.JsSettings.Deserialize;

namespace Test.Artic.Bot
{
    public class Start
    {
        // Variabili globali
        #region globals
        public TestVariable teVar;
        public RadiatorClass rad;
        public Deserialize json;
        public Setting set;
        ITelegramBotClient _client;
        #endregion
        // Variabile booleana per iniziare e smettere di ricevere informazioni
        #region listen
        public Start(ITelegramBotClient client)
        {
            // this is correct
            json = new Deserialize(this);
            teVar = new TestVariable();
            set = new Setting();
            rad = new RadiatorClass(this);
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
        // Metodi generali ed eventi
        #region methods
        // no?
        private void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            debug("Setting bunch of variables");
            // Variables 

            var message = messageEventArgs.Message;
            teVar.chatId = messageEventArgs.Message.Chat.Id;
            teVar.messageText = messageEventArgs.Message.Text;
            teVar.chatTitle = messageEventArgs.Message.Chat.Title;
            teVar.chatPhoto = messageEventArgs.Message.Chat.Photo;
            teVar.chatUserName = messageEventArgs.Message.Chat.Username;
            teVar.chatLastName = messageEventArgs.Message.Chat.LastName;
            teVar.chatFirstName = messageEventArgs.Message.Chat.FirstName;
            teVar.chatInviteLink = messageEventArgs.Message.Chat.InviteLink;
            teVar.chatDescription = messageEventArgs.Message.Chat.Description;

            success("Variables set!");
            C.WriteLine(teVar.chatId);
            debug("Configuring from JSON");
            readJSON();
            debug("This is a switch man, calling somthin i guess");
            switch (message.Type)
            {
                default:
                    break;
                case MessageType.Text:
                  rad.SwitchHelp(teVar.messageText, _client);
                    break;
                case MessageType.ChatMemberLeft:
                    break;
                case MessageType.ChatTitleChanged:
                    break;
                case MessageType.ChatMembersAdded:
                    break;
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
