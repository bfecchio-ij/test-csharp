using InfoJobs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoJobs.Dtos
{
    public class CandidatesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
       
        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public DateTime InsertDate { get; set; } 

        public DateTime? ModifyDate { get; set; }

     

        public int Age { get; set; }



    }
}
