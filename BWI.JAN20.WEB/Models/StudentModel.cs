using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BWI.JAN20.WEB.Models
{
    [Table("STUDENTS")]
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Column("FULL_NAME", TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address"), StringLength(150), Required(ErrorMessage = "Please Enter Your Email...")]
        [Column("EMAIL",TypeName ="VARCHAR(150)")]
        public string Email { get; set; }
        [Column("DATE_OF_BIRTH")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }

    }
}
