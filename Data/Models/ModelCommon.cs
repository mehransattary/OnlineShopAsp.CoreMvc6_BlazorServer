using System.ComponentModel.DataAnnotations;


namespace Data.Models;

public class ModelCommon
{
    [Key]
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

}
