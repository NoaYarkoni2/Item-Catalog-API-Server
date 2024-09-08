using System.ComponentModel.DataAnnotations;

namespace ItemCatalogAPI.Models
{
    public class TmplMessages
    {
        [Key]
        public required string ID { get; set; }
        public string? NAME { get; set; }
        public string? TMPLID { get; set; }
        public string? NEXTQUEST { get; set; }
        public string? MESTYPE { get; set; }
        public string? EXPECTTYPE { get; set; }
        public string? MESTEXT { get; set; }
        public string? VALIDATOR { get; set; }
        public string? BY_PASS_WHEN { get; set; }
        public string? WAITFORANSWER { get; set; }
        public string? BEAUTY { get; set; }
        public string? RAISE { get; set; }
        public string? RESPONSE { get; set; }
        public string? NOTIFY { get; set; }
        public string? SUBMIT_WH { get; set; }
        public string? COPY { get; set; }
        public DateTime? CREATED { get; set; }
    }
}
