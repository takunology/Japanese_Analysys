using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Werewolf_JSON
{
    [DataContract]
    public class JsonData
    {
        //[DataMember(Name = "id", IsRequired = false)] public int id = 0;

        [DataMember(Name = "token", IsRequired = false)]
        public string name { get; set; }
    }

    [DataContract]
    public partial class Welcome
    {
        [DataMember(Name = "@context")]
        public Uri[] Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "village")]
        public Village Village { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "phase")]
        public Phase Phase { get; set; }

        [DataMember(Name = "date")]
        public long Date { get; set; }

        [DataMember(Name = "phaseTimeLimit")]
        public long PhaseTimeLimit { get; set; }

        [DataMember(Name = "phaseStartTime")]
        public DateTimeOffset PhaseStartTime { get; set; }

        [DataMember(Name = "serverTimestamp")]
        public DateTimeOffset ServerTimestamp { get; set; }

        [DataMember(Name = "clientTimestamp")]
        public DateTimeOffset ClientTimestamp { get; set; }

        [DataMember(Name = "directionality")]
        public string Directionality { get; set; }

        [DataMember(Name = "intensionalDisclosureRange")]
        public string IntensionalDisclosureRange { get; set; }

        [DataMember(Name = "extensionalDisclosureRange")]
        public object[] ExtensionalDisclosureRange { get; set; }

        [DataMember(Name = "votingResultsSummary")]
        public VotingResultsSummary[] VotingResultsSummary { get; set; }

        [DataMember(Name = "votingResultsDetails")]
        public VotingResultsDetail[] VotingResultsDetails { get; set; }

        [DataMember(Name = "character")]
        public Character[] Character { get; set; }

        [DataMember(Name = "role")]
        public Role[] Role { get; set; }
    }

    [DataContract]
    public partial class Character
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "isMine")]
        public bool IsMine { get; set; }

        [DataMember(Name = "name")]
        public Name Name { get; set; }

        [DataMember(Name = "image")]
        public Uri Image { get; set; }

        [DataMember(Name = "id")]
        public long CharacterId { get; set; }

        [DataMember(Name = "status")]
        public Status Status { get; set; }

        [DataMember(Name = "update")]
        public Update Update { get; set; }

        [DataMember(Name = "isAChoice")]
        public bool IsAChoice { get; set; }
    }

    [DataContract]
    public partial class Name
    {
        [DataMember(Name = "en")]
        public string En { get; set; }

        [DataMember(Name = "ja")]
        public string Ja { get; set; }
    }

    [DataContract]
    public partial class Update
    {
        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "phase")]
        public Phase Phase { get; set; }

        [DataMember(Name = "date")]
        public long Date { get; set; }
    }

    [DataContract]
    public partial class Role
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "isMine")]
        public bool IsMine { get; set; }

        [DataMember(Name = "name")]
        public Name Name { get; set; }

        [DataMember(Name = "image")]
        public Uri Image { get; set; }

        [DataMember(Name = "numberOfCharacters")]
        public long NumberOfCharacters { get; set; }

        [DataMember(Name = "board")]
        public Board[] Board { get; set; }
    }

    [DataContract]
    public partial class Board
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "character")]
        public SourceCharacter Character { get; set; }

        [DataMember(Name = "polarity")]
        public string Polarity { get; set; }

        [DataMember(Name = "phase")]
        public Phase Phase { get; set; }

        [DataMember(Name = "date")]
        public long Date { get; set; }
    }

    [DataContract]
    public partial class SourceCharacter
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "id")]
        public long SourceCharacterId { get; set; }

        [DataMember(Name = "name")]
        public Name Name { get; set; }

        [DataMember(Name = "image")]
        public Uri Image { get; set; }
    }

    [DataContract]
    public partial class Village
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "id")]
        public long VillageId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "totalNumberOfCharacters")]
        public long TotalNumberOfCharacters { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }

        [DataMember(Name = "chatSettings")]
        public ChatSettings ChatSettings { get; set; }
    }

    [DataContract]
    public partial class ChatSettings
    {
        [DataMember(Name = "@context")]
        public Uri Context { get; set; }

        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "maxNumberOfChatMessages")]
        public long MaxNumberOfChatMessages { get; set; }

        [DataMember(Name = "maxLengthOfUnicodeCodePoints")]
        public long MaxLengthOfUnicodeCodePoints { get; set; }
    }

    [DataContract]
    public partial class VotingResultsDetail
    {
        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "sourceCharacter")]
        public SourceCharacter SourceCharacter { get; set; }

        [DataMember(Name = "targetCharacter")]
        public SourceCharacter TargetCharacter { get; set; }
    }

    [DataContract]
    public partial class VotingResultsSummary
    {
        [DataMember(Name = "@id")]
        public Uri Id { get; set; }

        [DataMember(Name = "characterToLynch")]
        public SourceCharacter CharacterToLynch { get; set; }

        [DataMember(Name = "numberOfVotes")]
        public long NumberOfVotes { get; set; }

        [DataMember(Name = "rankOfVotes")]
        public long RankOfVotes { get; set; }
    }

    public enum Status { Alive };

    public enum Phase { Morning };

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Werewolf_JSON.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Werewolf_JSON.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                StatusConverter.Singleton,
                PhaseConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "alive")
            {
                return Status.Alive;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            if (value == Status.Alive)
            {
                serializer.Serialize(writer, "alive");
                return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class PhaseConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Phase) || t == typeof(Phase?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "morning")
            {
                return Phase.Morning;
            }
            throw new Exception("Cannot unmarshal type Phase");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Phase)untypedValue;
            if (value == Phase.Morning)
            {
                serializer.Serialize(writer, "morning");
                return;
            }
            throw new Exception("Cannot marshal type Phase");
        }

        public static readonly PhaseConverter Singleton = new PhaseConverter();
    }

    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\takun\Desktop\学校用\プログラム設計法\werewolfworld-gh-pages\village\example\0.3\server2client\morning.jsonld";
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Character));
            FileStream fs = new FileStream(file, FileMode.Open);
            //var fs = File.ReadAllText(file);
            //JsonData json = (JsonData)js.ReadObject(fs);
            Character charjson = (Character)js.ReadObject(fs);
            //Role rolejson = (Role)js.ReadObject(fs);
            Console.WriteLine("name = {0}", charjson.Name);
            fs.Close();
            Console.ReadKey();
        }
    }
}
