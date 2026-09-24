using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storefront.Models;

public class MerchModel
{
    [Key]
    public int Item_ID { get; set; }

    public string ItemName { get; set; }

    public string ItemDesc { get; set; }

    public string ItemPrice { get; set; }

    public string ItemQuantity { get; set; }
}
