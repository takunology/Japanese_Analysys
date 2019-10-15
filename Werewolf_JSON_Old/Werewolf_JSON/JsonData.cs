using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

//Install-Package Newtonsoft.Json

namespace Werewolf_JSON
{
    class JsonData
    {
    }

    public partial class Welcome
    {
        [JsonProperty("@context")]
        public Uri[] Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("village")]
        public Village Village { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("phase")]
        public Phase Phase { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("phaseTimeLimit")]
        public long PhaseTimeLimit { get; set; }

        [JsonProperty("phaseStartTime")]
        public DateTimeOffset PhaseStartTime { get; set; }

        [JsonProperty("serverTimestamp")]
        public DateTimeOffset ServerTimestamp { get; set; }

        [JsonProperty("clientTimestamp")]
        public DateTimeOffset ClientTimestamp { get; set; }

        [JsonProperty("directionality")]
        public string Directionality { get; set; }

        [JsonProperty("intensionalDisclosureRange")]
        public string IntensionalDisclosureRange { get; set; }

        [JsonProperty("extensionalDisclosureRange")]
        public object[] ExtensionalDisclosureRange { get; set; }

        [JsonProperty("votingResultsSummary")]
        public VotingResultsSummary[] VotingResultsSummary { get; set; }

        [JsonProperty("votingResultsDetails")]
        public VotingResultsDetail[] VotingResultsDetails { get; set; }

        [JsonProperty("character")]
        public Character[] Character { get; set; }

        [JsonProperty("role")]
        public Role[] Role { get; set; }
    }

    public partial class Character
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("isMine")]
        public bool IsMine { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("id")]
        public long CharacterId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("update")]
        public Update Update { get; set; }

        [JsonProperty("isAChoice")]
        public bool IsAChoice { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }
    }

    public partial class Update
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("phase")]
        public Phase Phase { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }

    public partial class Role
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("isMine")]
        public bool IsMine { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("numberOfCharacters")]
        public long NumberOfCharacters { get; set; }

        [JsonProperty("board")]
        public Board[] Board { get; set; }
    }

    public partial class Board
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("character")]
        public SourceCharacter Character { get; set; }

        [JsonProperty("polarity")]
        public string Polarity { get; set; }

        [JsonProperty("phase")]
        public Phase Phase { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }

    public partial class SourceCharacter
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("id")]
        public long SourceCharacterId { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }
    }

    public partial class Village
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("id")]
        public long VillageId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totalNumberOfCharacters")]
        public long TotalNumberOfCharacters { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("chatSettings")]
        public ChatSettings ChatSettings { get; set; }
    }

    public partial class ChatSettings
    {
        [JsonProperty("@context")]
        public Uri Context { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("maxNumberOfChatMessages")]
        public long MaxNumberOfChatMessages { get; set; }

        [JsonProperty("maxLengthOfUnicodeCodePoints")]
        public long MaxLengthOfUnicodeCodePoints { get; set; }
    }

    public partial class VotingResultsDetail
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("sourceCharacter")]
        public SourceCharacter SourceCharacter { get; set; }

        [JsonProperty("targetCharacter")]
        public SourceCharacter TargetCharacter { get; set; }
    }

    public partial class VotingResultsSummary
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("characterToLynch")]
        public SourceCharacter CharacterToLynch { get; set; }

        [JsonProperty("numberOfVotes")]
        public long NumberOfVotes { get; set; }

        [JsonProperty("rankOfVotes")]
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
}
