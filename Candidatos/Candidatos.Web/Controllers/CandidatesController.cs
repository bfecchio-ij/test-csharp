using Candidatos.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private static string baseURL = "https://localhost:44317/api/v1";

        public async Task<IActionResult> Index()
        {
            List<CandidateDTO> result = new List<CandidateDTO>();

            var client = new RestClient($"{baseURL}/Candidate");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            result = JsonConvert.DeserializeObject<List<CandidateDTO>>(response.Content);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateDTO candidate)
        {
            if (ModelState.IsValid)
            {
                if (ExistEmail(candidate.Email))
                {
                    ModelState.AddModelError("Email", "Email já cadastrado");
                    return View(candidate);
                }

                var client = new RestClient($"{baseURL}/Candidate");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(candidate), ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);

                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = new RestClient($"{baseURL}/Candidate/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateDTO>(response.Content);
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CandidateDTO candidate)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"{baseURL}/Candidate/{candidate.IdCandidate}");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(candidate), ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);

                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = new RestClient($"{baseURL}/Candidate/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateDTO>(response.Content);
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CandidateDTO candidate)
        {
            var client = new RestClient($"{baseURL}/Candidate/{candidate.IdCandidate}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(candidate), ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = new RestClient($"{baseURL}/Candidate/Detail/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateDetails>(response.Content);
            return View(candidate);
        }

        
        public async Task<IActionResult> CreateExp(int id)
        {
            var client = new RestClient($"{baseURL}/Candidate/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateDTO>(response.Content);
            CandidateExperienceDTO experience = new CandidateExperienceDTO();
            experience.IdCandidate = candidate.IdCandidate;
            experience.CandidateName = candidate.Name;
            experience.CandidateSurname = candidate.Surname;
            experience.CandidateEmail = candidate.Email;
            experience.BeginDate = null;

            return View(experience);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExp(CandidateExperienceDTO experience)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"{baseURL}/CandidateExperience");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(experience), ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);

                return RedirectToAction("Index");
            }

            return View(experience);
        }

        public async Task<IActionResult> EditExp(int id)
        {
            var client = new RestClient($"{baseURL}/CandidateExperience/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateExperienceDTO>(response.Content);
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> EditExp(CandidateExperienceDTO experience)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"{baseURL}/CandidateExperience/{experience.IdCandidateExperience}");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(experience), ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);

                return RedirectToAction("Details", new { id = experience.IdCandidate });
            }
            return View(experience);
        }

        public async Task<IActionResult> RemoveExp(int id)
        {
            var client = new RestClient($"{baseURL}/CandidateExperience/{id}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            var candidate = JsonConvert.DeserializeObject<CandidateExperienceDTO>(response.Content);
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveExp(CandidateExperienceDTO experience)
        {
            var client = new RestClient($"{baseURL}/CandidateExperience/{experience.IdCandidateExperience}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(experience), ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            return RedirectToAction("Details", new { id = experience.IdCandidate });
        }

        protected bool ExistEmail(string email)
        {
            var client = new RestClient($"{baseURL}/Candidate/byEmail/{email}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request).Content == "true";

            return response;
        }
    }
}
