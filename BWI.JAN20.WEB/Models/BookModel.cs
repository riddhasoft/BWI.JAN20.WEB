using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace BWI.JAN20.WEB.Models
{
    [Table("BOOKS")]
    [Index(nameof(Publication), IsUnique = true)]
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Author { get; set; }
        [Range(1800, 2024)]
        
        public int Year { get; set; }
        
        [Column("RATE",TypeName="decimal(18,2) ")]
        public decimal   Rate { get; set; }
        public string? Publication { get; set; }
        
        public int? BookCategoryId { get; set; }
        [ValidateNever]
        public virtual BookCategoriesModel BookCategory { get; set; }
    }
    public class Constants
    {
       public const int YEAR = 0;
    }
}
