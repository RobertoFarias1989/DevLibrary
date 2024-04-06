﻿using DevLibrary.Application.Commands.CreateLoan;
using DevLibrary.Application.Commands.DeleteLoan;
using DevLibrary.Application.Commands.UpdateLoan;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "manager, student")]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLoanCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}