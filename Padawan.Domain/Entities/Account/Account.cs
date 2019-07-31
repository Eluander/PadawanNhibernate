using Flunt.Validations;
using Padawan.Shared;
using Padawan.Shared.Entities;
using Padawan.Shared.Messages;

namespace Padawan.Domain.Entities
{
    public class Account : Audit, IValidatable
    {
        public Account() { }

        public Account(string name, long createdByUserId) 
            : base(createdByUserId)
        {
            Name = name;
            Validate();
        }
        public virtual void Update(string name) 
        {
            Name = name;
            Validate();
        }
        public virtual void Delete()
        {
            Validate();
        }
        public virtual void Validate()
        {
            AddNotifications(new Flunt.Validations.Contract().Requires()
                .HasMaxLen(Name, Constantes.LENGTH_MAX, "Name", Messages.LENGTH_150_MAX)
                .HasMinLen(Name, Constantes.LENGTH_MIN, "Name", Messages.LENGTH_05_MIN));
        }
        public virtual string Name { get; protected set; }
    }
}
