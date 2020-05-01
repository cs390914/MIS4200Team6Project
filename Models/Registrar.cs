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
        
        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;
        
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        


        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
       

        [Display(Name = "Primary Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{3})-([0-9]{3})-([0-9]{4})$",
                   ErrorMessage = "Please enter phone number in format xxx-xxx-xxxx.")]
        //[DisplayFormat(DataFormatString = "\\d{3}-\\d{3}-\\d{4}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string Birthday { get; set; }


        [Display(Name = " Operating group")]
       
        public Group OGroup { get; set; }
        public enum Group
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            CustomerExperienceDesign,
            DataAnalytics,
            Digital,
            EnterpriseApplicationsSolutions,
            EnterpriseCollaboration,
            EnergyUtilities,
            FinancialServices,
            Healthcare,
            India,
            Indianapolis,
            Insurance,
            Louisville,
            MarketingOperationsCRM,
            Miami,
            MobileAppDevelopment,
            ModernSoftwareDelivery,
            MicrosoftPartnership,
            OperationalProcessExcellence,
            PeopleChange,
            Seattle,
            StLouis,
            TalentManagement,
            Tampa,
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