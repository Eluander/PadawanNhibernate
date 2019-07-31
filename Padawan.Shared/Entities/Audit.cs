using Flunt.Validations;
using Padawan.Shared.Enums;
using System;

namespace Padawan.Shared.Entities
{
    public class Audit : Entity
    {
        public Audit() { }

        public Audit(long createdByUserId)
        {
            CreatedDate = DateTime.Now;
            CreatedByUserId = createdByUserId;

            AddNotifications(new Flunt.Validations.Contract().Requires()
                .IsFalse(createdByUserId <= 0, "creadtedByUserId", ""));
        }

        public virtual DateTime CreatedDate { get; protected set; }
        public virtual long CreatedByUserId { get; protected set; }
    }
}
