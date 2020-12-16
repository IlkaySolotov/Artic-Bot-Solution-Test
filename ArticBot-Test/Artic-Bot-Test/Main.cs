/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using Telegram.Bot;

using Test.Artic.Bot;
using Test.Aritc.Monky;
using Test.Artic.Global;

using C = System.Console;

namespace Test.Artic
{
    // Absolute-Main class
    class MainClass
    {
        // Define classes and public variables
        static TestVariable var = new TestVariable();
        static monkyClass monkey = new monkyClass();
        // Main and only method in this class, calls the bot class (starts the whole thing)
        static void Main(string[] args)
        {
            C.WriteLine(monkey.monkyStr);
            debug("Setting Token");
            var.token = "1460237900:AAFE_MwvMzuUvcNl1FziCGt2YkcJA21lo54";
            success("Token Set");
            // Attribute the bot client a token
            debug("calling TelegramBotClient class");
            var botClient = new TelegramBotClient(var.token);
            success("TelegramBotClient class returned");
            // attribute start variable the telegram.bot.start() class
            debug("Calling Start class");
            var start = new Start(botClient);
            success("Called Start class");
            // start listening (starting the bot)
            debug("Start Listening");
            start.listen(true);
            C.ReadLine();
        }

        static void debug(string cause)
        {
            C.ForegroundColor = System.ConsoleColor.Yellow;
            C.WriteLine("[!] "+cause);
            C.ForegroundColor = System.ConsoleColor.White;
        }
        static void success(string cause)
        {
            C.ForegroundColor = System.ConsoleColor.Green;
            C.WriteLine("[+] " + cause);
            C.ForegroundColor = System.ConsoleColor.White;
        }
    }
}
