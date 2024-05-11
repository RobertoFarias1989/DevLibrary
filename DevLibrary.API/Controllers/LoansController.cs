using DevLibrary.Application.Commands.CreateLoan;
using DevLibrary.Application.Commands.DeleteLoan;
using DevLibrary.Application.Commands.UpdateLoan;
using DevLibrary.Application.Queries.GetAllLoans;
using DevLibrary.Application.Queries.GetLoanById;
using DevLibrary.Core.Entities;
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
        [HttpGet]
        [Authorize(Roles = "manager, student")]
        public async Task<IActionResult> Get() 
        { 
            var getAllLoansQuery = new GetAllLoansQuery();

            var loan = await _mediator.Send(getAllLoansQuery);

            return Ok(loan);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLoanByIdQuery(id);

            var loan = await _mediator.Send(query);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);

        }

        [HttpPost]
        [Authorize(Roles = "manager, student")]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("renew/{id}")]
        [Authorize(Roles = "manager")]
        //Deixaria o nome do método como Put ou coloria algo personalizado tal como: RenewedLoan?
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("return/{id}")]
        [Authorize(Roles = "manager")]
        //Deixaria o nome do método como Delete ou coloria algo personalizado tal como: ReturnedLoan?
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLoanCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
