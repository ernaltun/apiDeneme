using System.ComponentModel.DataAnnotations;

namespace apiDeneme.Models
{
    public class Works
    {
        public int Id { get; set; }
        public string AracPlaka { get; set; }
        public string AracSofor { get; set; }
        public string SoforTel { get; set; }
        public string CıkısNoktası { get; set; }
        public string TeslimatNoktası { get; set; }
        public DateTime Tarih { get; set; }

    }
}
