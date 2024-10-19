using System.ComponentModel.DataAnnotations;

namespace AppBank.Models.Entities
{
    public class CashType
    {
        [Key]
        public int CashID { get; set; }
        public int TypeCash { get; set; }
        public decimal CashValue { get; set; }
        public int IsVisible { get; set; }
        public int StatusID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
