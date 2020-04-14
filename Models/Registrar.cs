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
        

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string EmailAddress { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string LastName { get; set; }
        [Display(Name = "Primary Phone")]
        [Phone]
        
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

 
        [Display(Name = "Job Positions")]
        public jobs Centric { get; set; }
        public enum jobs
        {
            Consultant,
        SeniorConsultant = 1,
        Manager = 2,
        Architect = 3,
        SeniorManager = 4,
         SeniorArchitect = 5,
         PrincipalArchitect = 6,
          Partner = 7

        }





        
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

    }
}