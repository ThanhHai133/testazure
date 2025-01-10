using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class MonAn
    {
        [Key]
        public int MaMonAn { get; set; }
        public string? TenMonAn { get; set; }
        public decimal? GiaMonAn { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? AnhMonAn { get; set; }
    }
}
