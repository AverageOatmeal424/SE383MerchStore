using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storefront.Models;

public class MerchModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Item_ID { get; set; }

    [Required]
    [StringLength(200)]
    public string ItemName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string ItemDesc { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "999999999")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ItemPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int ItemQuantity { get; set; }
}
