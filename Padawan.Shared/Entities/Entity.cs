using Flunt.Notifications;

namespace Padawan.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity() { }

        public virtual long Id { get; protected set; }
    }
}
