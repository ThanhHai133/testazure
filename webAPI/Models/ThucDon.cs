using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class ThucDon
    {
        [Key]
        public int Mathucdon { get; set; }
        public string Tenthucdon { get; set; }
    }
}
