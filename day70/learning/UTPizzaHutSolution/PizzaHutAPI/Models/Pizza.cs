using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PizzaHutAPI.Models
{
    public enum PizzaStatus
    {
        [Description("Pizza is Available")]
        Available,
        [Description("Pizza is UnAvailable")]
        UnAvailable,
        [Description("Pizza is Preparing")]
        Pepareing,
        [Description("Pizza is not In Menu")]
        NotInMenu
    }
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QtyInHand { get; set; }
        public PizzaStatus status { get; set; } = PizzaStatus.UnAvailable;
    }
}
