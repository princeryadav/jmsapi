﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Repository;
using DTO.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobMaster _job;
        public JobController(IJobMaster job)
        {
            _job = job;
        }

        // public ICompanyMaster _Comp { get; }

        [HttpPost]
        [Route("JobRegister")]
        public async Task<IActionResult> JobRegistration([FromBody]JobMasterDto jobDetails)
        {
            IActionResult response = Unauthorized();
            SingleReturnResult<string> newJobDetails = await _job.AddUpdateJob(jobDetails);
            response = Ok(newJobDetails);
            return response;
        }

        [HttpGet]
        [Route("JobDetails")]
        public async Task<IActionResult> JobDetails()
        {
            IActionResult response = Unauthorized();
            ListReturnResult<JobMasterDto> jobDetails = await _job.GetAllJob();
            response = Ok(jobDetails);
            return response;
        }

        [HttpGet("{id}")]
       // [Route("CompanyDetails")]
        public async Task<IActionResult> JobDetail(int id)
        {
            IActionResult response = Unauthorized();
            SingleReturnResult<JobMasterDto> jobDetail = await _job.GetJob(id);
            response = Ok(jobDetail);
            return response;
        }

        //[HttpPost]
        //[Route("updateDetails")]
        //public async Task<IActionResult> updateDetails([FromBody] CompanyMasterDto companyDetails)
        //{
        //    IActionResult response = Unauthorized();
        //    SingleReturnResult<CompanyMasterDto> companyDetail = await _comp.updateCompany(companyDetails);
        //    response = Ok(companyDetail);
        //    return response;
        //}
    }
}