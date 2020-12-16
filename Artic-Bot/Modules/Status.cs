/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using System;
using System.Collections.Generic;

using Artic_Bot.Modules;
using Artic_Bot.JsSettings;

namespace Artic_Bot.Status
{
    // Class to check settings status and eventually call the following module
    class Check
    {
        // Define classes and public variables
        #region Variables
        Setting setting = new Setting ();
        Module  module  = new Module  ();
        #endregion
        #region Methods
        // Main method for this class, checks the settings status and stores it
        void Checker()
        {
            // List to store setting and attribute it it's right module
            List<(Func<bool> Checker, Action Method)> actions = new List<(Func<bool> Checker, Action Method)> {
            (() => setting.Join        , () => module.Join        ()),
            (() => setting.Leave       , () => module.Leave       ()),
            (() => setting.ChangeTitle , () => module.ChangeTitle ())
            };
            // Call the method if the called setting results true
            foreach (var p in actions)
                if (p.Checker() == true)
                    p.Method();
        }
        #endregion
    }
}
