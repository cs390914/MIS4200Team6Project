using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team6.Models
{
    public class Registrar
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Primary Phone")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Job Title")]
        public string Birthday { get; set; }
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]

        public string OperatingGroup { get; set; }
        [Display (Name = " Operating group")]

        public Group OGroup { get; set; }

        public enum Group
        {
            CustomerExperienceDesign,
            DataAnalytics,
            Digital,
            EnterpriseApplicationsSolutions,
            EnterpriseCollaboration,
            EnergyUtilities,
            FinancialServices,
            Healthcare,
            Insurance,
            MarketingperationsCRM,
            MobileAppDevelopment,
            ModernSoftwareDelivery,
            MicrosoftPartnership,
            OperationalProcessExcellence,
            PeopleChange,
            TalentManagement,
            TechnologySolutionServices

        }
        

        public string Position { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

    }
}