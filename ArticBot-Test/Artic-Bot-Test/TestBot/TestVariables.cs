/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using Telegram.Bot;
using Telegram.Bot.Types;

namespace Test.Artic.Global
{
    public class TestVariable
    {
        //public ITelegramBotClient _client;

        // Configuration variables 
        public string  token           { get; set; }  // Bot's token
        public string  cmdPrefix       { get; set; }  // Bot's commands prefix
        // Chat variables 
        public long    chatId          { get; set; }  // Id              of the chat where message has been sent
        public string  chatDescription { get; set; }  // Description     of the chat where message has been sent 
        public string  chatFirstName   { get; set; }  // FirstName       of the chat where message has been sent
        public string  chatLastName    { get; set; }  // LastName        of the chat where message has been sent
        public string  chatUserName    { get; set; }  // ChatTag         of the chat where message has been sent
        public string  chatTitle       { get; set; }  // ChatTitle       of the chat where message has been sent
        public string  chatInviteLink  { get; set; }  // ChatInviteLink  of the chat where message has been sent
        // Message variables 
        public string  messageText     { get; set; }  // MessageContent  of the message
        // SubChat Class variables 
        public ChatPhoto chatPhoto = new ChatPhoto(); // ChatPicture    of the chat where message has been sent



    }
}
