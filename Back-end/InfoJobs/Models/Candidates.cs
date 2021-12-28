using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoJobs.Models
{
    [Table("Candidates")]
    public class Candidates
    {



        [Key()]
        public int Id { get; set; }
            
             
            



        public string Name { get; set; }

        public string Surname { get; set; }


       
        public DateTime Birthday { get; set; } 



        
        public string Email { get; set; }
       
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyDate { get; set; } = null;

        public  virtual ICollection<CandidateExperiences> Experiences { get; set; }
       

        



        public Candidates()
        {

        }
      
        public Candidates(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            InsertDate = DateTime.Now;
            ModifyDate = null;
            Surname = "Complete";
           

        }

        //public Candidates(int id, string name, DateTime birthday, string email, DateTime insertDate, DateTime? modifyDate)
        //{
        //    Id = id;
        //    Name = name;
        //    Birthday = birthday;
        //    Email = email;
        //    InsertDate = DateTime.Now;
        //    ModifyDate = null;
        //}



    }
}
