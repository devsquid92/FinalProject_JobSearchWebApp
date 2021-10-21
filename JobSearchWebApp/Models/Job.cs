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

    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.SavedJobs = new HashSet<SavedJob>();
        }
    
        public int JobsId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Title { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ComName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is missing.")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$",
            ErrorMessage = "Email address is not valid yo")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is missing.")]
        //[RegularExpression("^[0-9]{12,12}*$", ErrorMessage = "Phone number must be numeric and miniumum of 12.")]
        public int Phone { get; set; }

        [Display(Name = "Addess")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Enter closing date.")]
        public System.DateTime Date { get; set; }

        [Display(Name = "Job Description:")]
        [Required(ErrorMessage = "Job Description is required.")]
        public string JobDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SavedJob> SavedJobs { get; set; }
    }
}
