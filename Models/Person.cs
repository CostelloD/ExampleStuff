using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestExamples.Models
{
    public class Person
    {
        [Key]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a First for the child")]
        [MinLength(2, ErrorMessage = "First Name must contain at least two characters")]
        public string ChildFirstNAme { get; set; }


        //set PPS number as the primary key using the [Key] tag
        //[Key]
        //[Required(ErrorMessage = "Please Enter a PPS Number")]
        //[RegularExpression(@"^(\d{7})([a-zA-Z]{1,2})$", ErrorMessage = "Not an valid PPS Number")]
        //public string PPSNumber { get; set; }

        [Required(ErrorMessage = "Please enter a date of birth for the child")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [BirthDate]
        public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Please Select your childs gender")]
        //public string Gender { get; set; }



        //[Required(ErrorMessage = "Please enter your address")]
        //public string Address { get; set; }


        //Regex specific to Irish mobile number
        [Required(ErrorMessage = "Please enter your Mobile Phone Number")]
        [Display(Name = "Mobile Phone Number")]
        [RegularExpression(@"^(08)([3-9])(\s?)(\d{7})", ErrorMessage = "Not a Valid Irish Mobile Number, please check and try again")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneMobile { get; set; }

        ////more flexible Regex for second and alternate numbers
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^(\D?)(\d{2,5})?\D?\d{2,3}(\D?)(\D?)\d{7}", ErrorMessage = "Not a vaild Phone Number, please check and try again")]
        //public string PhoneSecond { get; set; }

        //[Required(ErrorMessage = "Please enter an alternate contact number")]
        //[RegularExpression(@"^(\D?)(\d{2,5})?\D?\d{2,3}(\D?)(\D?)\d{7}", ErrorMessage = "Not a Valid Phone Number, please check and try again")]
        //[DataType(DataType.PhoneNumber)]
        //public string PhoneThird { get; set; }

        ////Regex added for email format
        //[Required(ErrorMessage = "Please enter an email address")]
        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Not a Valid email address, please check and try again")]
        //[DataType(DataType.EmailAddress)]
        //public string FirstEmailAddress { get; set; }


        /*days saved as an int and used custom enum that has 5 days, the days are assigned prime number
         * values in the cshtml and their product taken as property value. This is then undone when and relisted as
         text when viewed in the pages. Minimum value of 3 ensures that at least 1 day is selected (Monday's value is 3,
         the first of the primes that were used)*/
        //[Range(3, 15015, ErrorMessage = "Please select one or more days")]
        //[Required(ErrorMessage = "Please select the days for your child to attend")]
        //public int DaysRequested { get; set; }

        //[Required(ErrorMessage = "Please Select Partime or Fulltime option")]
        //public int HoursRequested { get; set; }

        //used the [DisplayFormat] to render dates
        [Required(ErrorMessage = "Please Select a Startdate for your child")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        ////[StartDate]
        public DateTime StartDate { get; set; }



    }
}
