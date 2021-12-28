using AutoMapper;
using InfoJobs.Data.Repository;
using InfoJobs.Dtos;
using InfoJobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoJobs.Services
{
    public class CandidatesServices : ICandidatesServices
    {

        private readonly ICandidatesRepo _repo;
        private readonly IMapper _mapper;

        public CandidatesServices(ICandidatesRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

       

        public async Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync()
        {


            var candidates = await _repo.GetAllCandidatesAsync();


            return _mapper.Map<IEnumerable<CandidatesDto>>(candidates);



        }



        public async Task<CandidatesDto> GetCandidateAsyncById(int idCandidate)
        {

            var candidate = await _repo.GetCandidatesAsyncById(idCandidate);

            return _mapper.Map<CandidatesDto>(candidate);


        }


        public async Task<CandidatesDto> PostCandidateAsync(CandidatesRequestDto candidateDto)
        {


            try
            {

                var candidate = _mapper.Map<Candidates>(candidateDto);

                _repo.Add(candidate);


                if (await _repo.SaveChangesAsync())
                {
                    var response = _mapper.Map<CandidatesDto>(candidate);
                    return response;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            } catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<CandidatesDto> UpdateCandidateAsyncById(int id, CandidatesRequestDto candidateDto)
        {


            try {


            


                var candidateFinded  = await _repo.GetCandidatesAsyncById(id);

                if (candidateFinded == null) { throw new Exception(); }

                 _mapper.Map(candidateDto, candidateFinded);


                _repo.Update(candidateFinded);


                if (await _repo.SaveChangesAsync())
                {

                    var response = _mapper.Map<CandidatesDto>(candidateDto);
                    return response;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<string> DeleteCandidateAsyncById(int id)
        {

            try
            {

                var candidateFinded = await _repo.GetCandidatesAsyncById(id);

                if (candidateFinded == null) { throw new Exception(); }

               


                _repo.Delete(candidateFinded);
                if (await _repo.SaveChangesAsync())
                {

                    return "Candidato Deletado Com sucesso.";
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }








        }
    }


    }

    
