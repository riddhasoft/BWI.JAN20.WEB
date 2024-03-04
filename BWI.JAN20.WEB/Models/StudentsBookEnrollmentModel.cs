using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace BWI.JAN20.WEB.Models
{
    public class StudentsBookEnrollmentModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ValidateNever]
        public virtual BookModel? Book { get; set; }
        [ValidateNever]
        public virtual StudentModel? Student { get; set; }
    }
}
