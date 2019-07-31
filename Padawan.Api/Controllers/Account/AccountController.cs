using Microsoft.AspNetCore.Mvc;
using Padawan.Domain.Commands;
using Padawan.Domain.Entities;
using Padawan.Domain.Handlers;
using Padawan.Domain.Repositories;
using Padawan.Shared;
using Padawan.Shared.Commands;
using Padawan.Shared.Entities;
using Padawan.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padawan.Api.Controllers
{
    [Route(Constantes.API + "v1/cadastros")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _repository;
        private readonly AccountHandler _handler;

        public AccountController(IAccountRepository repository, AccountHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromBody] Filter filter)
        {
            try
            {
                List<Account> result = await _repository.GetList(filter.Page, filter.PageSize);
                if (result.Count == 0)
                    return Ok(new CommandResult(false, Messages.NO_RECORDS_FOUND, null));
                else
                    return Ok(new CommandResult(true, result.Count.ToString() + " Cadastro(s) encontrado(s).", result));
            }
            catch (Exception e)
            {
                return BadRequest(new CommandResult(false, e.Message, null));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            Account account = await _repository.GetById(id);
            if (account == null)
                return Ok(new CommandResult(false, Messages.NO_RECORDS_FOUND, null));
            else
                return Ok(new CommandResult(true,"Registro encontrado",
                    new AccountCommandResult
                    {
                        Id = account.Id,
                        Name = account.Name.ToString(),
                        CreatedDate = account.CreatedDate,
                        CreatedByUserId = account.CreatedByUserId,
                    }));
        }

        [HttpPost]
        public async Task<ICommandResult> Post([FromBody]CreateAccountCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result;
        }

        [HttpPut]
        public async Task<ICommandResult> Put([FromBody]EditAccountCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ICommandResult> Delete(long id)
        {
            var command = new DeleteAccountCommand
            {
                Id = id
            };
            ICommandResult result = await _handler.Handle(command);
            return result;
        }
    }
}