using System;
using System.Collections.Generic;
using System.Linq;
using teste_csharp.Models;

namespace teste_csharp.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();
            if (context.candidates.Any())
            {
                return;
            }
            var candidates = new Candidate[]
            {
            new Candidate { Name="José"},
            new Candidate { Name="Joao"}
            };
            foreach (Candidate d in candidates)
            {
                context.candidates.Add(d);
            }
            //if (context.candidateExperiences.Any())
            //{
            //    return;
            //}
            //var candidatesExp = new CandidateExperience[]
            //{
            //new CandidateExperience { Job="Dev"},
            //new CandidateExperience { Job="QA"}
            //};
            //foreach (CandidateExperience e in candidatesExp)
            //{
            //    context.candidateExperiences.Add(e);
            //}
            context.SaveChanges();
        }
    }
}
