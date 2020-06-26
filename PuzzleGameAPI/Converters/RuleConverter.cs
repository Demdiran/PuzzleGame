using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PuzzleGameDomain;
using PuzzleGameDomain.Rules;

namespace PuzzleGameAPI.Converters
{
    public class RuleConverter : JsonConverter<Rule>
    {
        public override Rule Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int id = 0;
            string type = "";
            while (reader.Read())
            {
                if(reader.TokenType == JsonTokenType.PropertyName)
                    switch (reader.GetString())
                    {
                        case "id":
                            reader.Read();
                            id = reader.GetInt32();
                            break;
                        case "type":
                            reader.Read();
                            type = reader.GetString();
                            break;
                    }
                else if(reader.TokenType == JsonTokenType.EndObject) break;
            }

            Rule result = type switch
            {
                "PuzzleGameDomain.Rules.StandardRowRule" => new StandardRowRule(),
                "PuzzleGameDomain.Rules.StandardColumnRule" => new StandardColumnRule(),
                "PuzzleGameDomain.Rules.StandardBoxRule" => new StandardBoxRule(),
                _ => throw new NotSupportedException(type + " is not a supported rule type."),
            };
            result.Id = id;
            return result;
        }

        public override void Write(Utf8JsonWriter writer, Rule value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("id", value.Id);
            var type = value.GetType().ToString();
            writer.WriteString("type", type);
            writer.WriteEndObject();
        }
    }
}