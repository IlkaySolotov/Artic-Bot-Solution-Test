/* 
 
  <=[Artic-Bot]=>
  
  [Author] - Ilkay Solotov
  [CreationDate] - 12/12/20
  [LastUpdate] - 13/12/20

*/

/* ɪ ᴋɴᴏᴡ ᴍᴏꜱᴛ ᴏꜰ ᴛʜᴏꜱᴇ ꜰᴏʀᴍᴀᴛᴛɪɴɢ ᴛʏᴘᴇꜱ ᴀʀᴇ ᴄᴏᴍᴘʟᴇᴛᴇʟʏ
    ᴡʀᴏɴɢ, ʙᴜᴛ ɪᴛꜱ ᴍʏ ᴘᴇʀꜱᴏɴᴀʟ ᴡᴀʏ ᴛᴏ ꜰᴏʀᴍᴀᴛ ᴍʏ ᴄᴏᴅᴇ :+) */

using System;
using System.IO;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Artic_Bot.Global;

namespace Artic_Bot.JsSettings
{
    // JSON Serialization / Deserialization Class
    class DeSeRialize
    {
        // Define classes and public variables
        #region variables
        Variable var = new Variable();
        Setting self = new Setting();
        #endregion
        // Serialize settings to JSON and write them to JSON file
        public void serialize() {
            File.WriteAllText(var.chatId.ToString(), JsonConvert.SerializeObject(self, Converter.Settings)); }
        // Deserialize settings to be used on restart
        public void deserialize() {
            JsonConvert.DeserializeObject<Setting>(File.ReadAllText(var.chatId.ToString()), Converter.Settings); }
    }
    // Settings Class where all setting's bools are stored ready for JSON serialization and toggling
    public partial class Setting
    {
        [JsonProperty("join")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool Join { get; set; }
        //
        [JsonProperty("Leave")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool Leave { get; set; }
        //
        [JsonProperty("changeTitle")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool ChangeTitle { get; set; }
    }
    // JSON Stuff, no need to touch those
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}