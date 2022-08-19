using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CallCenterAPI.Application.CQRS.Commands.Request;
using CallCenterAPI.Application.CQRS.Commands.Response;
using CallCenterAPI.Application.CQRS.Query.Request;
using CallCenterAPI.Application.CQRS.Query.Response;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Application.ViewModels;
using CallCenterAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCallRecordCommandRequest request)
        {
            CreateCallRecordCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteCallRecordCommandRequest request)
        {
            DeleteCallRecordCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public  async Task<IActionResult> GetAll([FromQuery]GetAllCallRecordsQueryRequest request)
        {
            GetAllCallRecordsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery]GetByIdCallRecordsQueryRequest request)
        {
            GetByIdCallRecordsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
