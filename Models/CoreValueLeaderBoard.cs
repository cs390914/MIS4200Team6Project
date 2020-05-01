using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MIS4200Team6.Models
{
    public class CoreValueLeaderBoard
    {
        [Key] // the data annotation is necessary because there is a field called, ID,
              // in the table and it is not the PK for the record
        public int leaderboardID { get; set; }

        //ID of person being recognized
        public Guid ID { get; set; }
        [ForeignKey(name: "ID")]
        public virtual Registrar Registrar { get; set; }
        public enum Values
        {
            stewardship,
            Culture = 1,
            DeliveringExcellence = 2,
            Innovation = 3,
            GreaterGood = 4,
            IntrgrityandOpenness = 5,
            Balance = 6,

        }

        [Display(Name = " Reason for Recognition")]
        public string Comment { get; set; }

        [Display(Name = "Recognition Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime TodaysDate { get; set; }



    }
}