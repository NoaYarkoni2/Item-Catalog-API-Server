using System.ComponentModel.DataAnnotations;

namespace ItemCatalogAPI.Models
{
    public class TmplAttrs
    {
        [Key]
        public required string ID { get; set; }
        public string? PAR_MESSAGE_ID { get; set; }
        public int? SEQ { get; set; }
        public string? ATTR_NAME { get; set; }
        public string? ATTR_VAL { get; set; }
        public string? NEXTQUEST { get; set; }
        public string? AVAILABLE { get; set; }
        public string? RESPONSE { get; set; }
        public DateTime? CREATED { get; set; }
    }
}


