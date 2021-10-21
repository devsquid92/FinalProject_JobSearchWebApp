//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobSearchWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.SavedJobs = new HashSet<SavedJob>();
        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FName { get; set; }


        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LName { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is missing.")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$",
            ErrorMessage = "Email address is not valid yo")]
        public string Email { get; set; }


        [Display(Name = "Phone:")]
        [Required(ErrorMessage = "Phone is missing.")]
        //[RegularExpression(@"([0-9]+)", ErrorMessage = "Phone number must be numeric and miniumum of 11.")]
        public Nullable<int> Phone { get; set; }

        [Display(Name = "Date of birth:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Display(Name = "Gender:")]
        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Gender { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password:")]
        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SavedJob> SavedJobs { get; set; }
    }
}
