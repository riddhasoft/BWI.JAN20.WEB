using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BWI.JAN20.WEB.ValidationFilter
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           // if (value.ToString().Length > 8)
            {
                return true;
            }
            //var upperCaseCheck = Regex.Match(value.ToString(), "/[A-Z]/");
            //if (!upperCaseCheck.Success)
            //{
            //    ErrorMessage = "Must Contains Uppercase";
            //}



            ErrorMessage = "Length Must be Greater Than 8 Character";
            return false;
        }
    }
}
