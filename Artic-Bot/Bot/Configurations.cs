/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Artic_Bot.JsSettings;

namespace Artic_Bot.Configurations
{
    // Configuration class
    class Configure
    {
        // Define classes and public variables
        #region variables
        Setting setting = new Setting(); // Settings class used for bools
        #endregion
        #region reset
        // Reset all settings
        public Task Reset()
        {
            setting.Join = true;
            setting.Leave = true;
            setting.ChangeTitle = true;
            return Reset();
        }
        #endregion
        /* Useless, will be needed soon or later to change settings throught modules
        
        public Task Change(string boolean, string flag)
        {
            var prop = typeof(Setting).GetProperty(boolean, BindingFlags.Public | BindingFlags.IgnoreCase);
            prop.SetValue(setting, bool.Parse(flag));
            return Change(boolean, flag);
        }

        */
    }
}