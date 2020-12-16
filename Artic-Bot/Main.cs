/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using Telegram.Bot;

using Artic_Bot.Bot;
using Artic_Bot.Global;

namespace Artic_Bot
{
    // Absolute-Main class
    class MainClass
    {
        // Define classes and public variables
        #region variables
        static Variable var = new Variable();
        #endregion
        // Main and only method in this class, calls the bot class (starts the whole thing)
        static void Main(string[] args)
        {
            // Attribute the bot client a token
            var botClient = new TelegramBotClient(var.token);
            // attribute start variable the telegram.bot.start() class
            var start = new Start(botClient);
            // start listening (starting the bot)
            start.listen(true);
        }
    }
}
