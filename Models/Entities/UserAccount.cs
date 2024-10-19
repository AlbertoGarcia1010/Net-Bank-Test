using System.ComponentModel.DataAnnotations;

namespace AppBank.Models.Entities
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        public string UserNameComplete { get; set; }
        public string Account { get; set; }
        public string UserPassword { get; set; }
        public decimal Quantity { get; set; }
        public int StatusID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
