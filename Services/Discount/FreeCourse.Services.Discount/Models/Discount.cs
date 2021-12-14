using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeCourse.Services.Discount.Models
{
    [Table("discount")]
    
    public class Discount
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
