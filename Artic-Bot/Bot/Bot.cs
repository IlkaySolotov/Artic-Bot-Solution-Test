/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

using Artic_Bot.Global;
using Artic_Bot.JsSettings;
using Artic_Bot.Status;

using _File = System.IO.File;

namespace Artic_Bot.Bot
{
    // Main class
    class Start
    {
        // Define classes and public variables
        #region globals
        DeSeRialize json = new DeSeRialize(); // Class for JSON serialization & deserializations
        Variable var = new Variable(); // Class for public variables
        Setting set = new Setting(); // Class for public Bools  & Settings 
        Check check = new Check(); // Class to check Modules & Settings status
        // Telegram Bot Client
        readonly ITelegramBotClient _client;
        #endregion
        // Start & Stop listening 
        #region listen
        public void listen(bool status)
        {
            if (status == true) _client.StartReceiving(); // Case call is true, start listening
            else _client.StopReceiving(); // Case call is false, stop listening 
        }
        #endregion
        // Client set for _client, local var client and OnMessage event
        #region client
        public Start(ITelegramBotClient client)
        {
            _client = client;
            client.OnMessage += OnMessage;
        }
        #endregion
        // All methods for this class, OnMessage, SettingsCheck, etc
        #region methods
        private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            // Define global variables with the OnMessage ones, this way you can use them everywhere if needed
            #region =Variables
            /*
               Variables are stored here:
               Bot (Folder)
                 - Variables.cs (ClassFile)
                   - Artic_Bot.Global (NameSpace)
                     - Variable (Class)
            */
            // Variables regarding Chat
            #region ->chat
            var.chatId = messageEventArgs.Message.Chat.Id;
            var.chatDescription = messageEventArgs.Message.Chat.Description;
            var.chatFirstName = messageEventArgs.Message.Chat.FirstName;
            var.chatLastName = messageEventArgs.Message.Chat.LastName;
            var.chatTitle = messageEventArgs.Message.Chat.Title;
            var.chatInviteLink = messageEventArgs.Message.Chat.InviteLink;
            var.chatPhoto = messageEventArgs.Message.Chat.Photo;
            var.chatUserName = messageEventArgs.Message.Chat.Username;
            #endregion
            // Variables regarding Messages
            #region ->message
            var.messageText = messageEventArgs.Message.Text;
            #endregion
            // Just Variables
            #region ->local
            var message = messageEventArgs.Message;
            string[] text = var.messageText.Remove(var.prefix).Split(" ");
            #endregion
            #endregion
            // Temporarely useless, will be needed to call proper methods, will be used later
            switch (message.Type)
            {
                case MessageType.Text: break;
                case MessageType.ChatMembersAdded: break;
                case MessageType.ChatMemberLeft: break;
                case MessageType.ChatTitleChanged: break;
                default: break;
            }
        }
        // Create JSON configuration file if not existing
        public Task SettingsCheck()
        {
            if (_File.Exists(var.chatId.ToString())) json.deserialize();
            else json.serialize();
            return SettingsCheck();
        }
        #endregion
    }
}
