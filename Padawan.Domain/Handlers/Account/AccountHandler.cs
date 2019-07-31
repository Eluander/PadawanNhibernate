using Flunt.Notifications;
using Padawan.Domain.Commands;
using Padawan.Domain.Entities;
using Padawan.Domain.Repositories;
using Padawan.Shared.Commands;
using Padawan.Shared.Messages;
using System.Threading.Tasks;

namespace Padawan.Domain.Handlers
{
    public class AccountHandler : Notifiable,
        ICommandHandler<CreateAccountCommand>,
        ICommandHandler<EditAccountCommand>,
        ICommandHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ICommandResult> Handle(CreateAccountCommand command)
        {
            
            Account account = new Account(command.Name,command.CreatedByUserId);

            
            AddNotifications(account.Notifications);

            if (!Valid)
                return new CommandResult(
                    false,
                    Messages.NOTIFICATIONS,
                    Notifications);

             await _accountRepository.Create(account);

            return new CommandResult(
                true,
                Messages.RECORDED_WITH_SUCCESS,
                new AccountCommandResult
                {
                    Id = account.Id,
                    Name = account.Name,

                    CreatedDate = account.CreatedDate,
                    CreatedByUserId = account.CreatedByUserId
                });
        }

        public async Task<ICommandResult> Handle(EditAccountCommand command)
        {
            Account account = await _accountRepository.GetById(command.Id);
            if (account == null)
                return new CommandResult(false, Messages.Account_NOT_FOUND, null);

            
            account.Update(command.Name);

            
            AddNotifications(account.Notifications);

            if (!Valid)
                return new CommandResult(
                    false,
                    Messages.NOTIFICATIONS,
                    Notifications);

            await _accountRepository.Update(account);

            return new CommandResult(
                true,
                Messages.UPDATED_WITH_SUCCESS,
                new AccountCommandResult
                {
                    Id = account.Id,
                    Name = account.Name,

                    CreatedDate = account.CreatedDate,
                    CreatedByUserId = account.CreatedByUserId,
                });
        }

        public async Task<ICommandResult> Handle(DeleteAccountCommand command)
        {
            Account account =  await _accountRepository.GetById(command.Id);
            if (account == null)
                return new CommandResult(false, Messages.Account_NOT_FOUND, null);

            await _accountRepository.Delete(account);

            return new CommandResult(
                true,
                Messages.DELETED_WITH_SUCCESS,
                new AccountCommandResult
                {
                    Id = account.Id,
                });
        }
    }
}
