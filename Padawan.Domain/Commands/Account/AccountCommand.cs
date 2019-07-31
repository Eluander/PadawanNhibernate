using Padawan.Shared.Commands;
using System;

namespace Padawan.Domain.Commands
{
    public class AccountCommandResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedByUserId { get; set; }
    }

    public class CreateAccountCommand : ICommand
    {
        public string Name { get; set; }
        public long CreatedByUserId { get; set; }
    }

    public class DeleteAccountCommand : ICommand
    {
        public long Id { get; set; }
    }

    public class EditAccountCommand : ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
