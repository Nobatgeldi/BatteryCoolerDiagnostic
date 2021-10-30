using Newtonsoft.Json;

namespace BatteryCoolerDiagnostic.Covisart
{
    public class CANSTATE 
    {
        public string Name { get; set; }
        public object Message { get; set; }
        public string Unit { get; set; }
        public int Length { get; set; }
    };
    public class CANDATA
    {
        public string Name { get; set; }
        public string Message { get; set; }

        [JsonProperty("Multiplexing/Group")]
        public string MultiplexingGroup { get; set; }
        public string Startbit { get; set; }

        [JsonProperty("Length [Bit]")]
        public string LengthBit { get; set; }

        [JsonProperty("Byte Order")]
        public string ByteOrder { get; set; }

        [JsonProperty("Value Type")]
        public string ValueType { get; set; }

        [JsonProperty("Initial Value")]
        public string InitialValue { get; set; }
        public string Factor { get; set; }
        public string Offset { get; set; }
        public string Minimum { get; set; }
        public string Maximum { get; set; }

        [JsonProperty("Value Table")]
        public string ValueTable { get; set; }
        public string Comment { get; set; }

        [JsonProperty("Message ID")]
        public string MessageID { get; set; }
        public string Unit { get; set; }

        public void convertBit() 
        {
            Startbit = (int.Parse(Startbit)/8).ToString();
        }
    }
}
