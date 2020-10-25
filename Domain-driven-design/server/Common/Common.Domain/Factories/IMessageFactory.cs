namespace PetFoodShop.Domain.Factories
{
    using Exceptions;
    using Models;

    public interface IMessageFactory : IFactory<Message>
    {
        IMessageFactory WithObjectData(object data);
    }

    internal class MessageFactory : IMessageFactory
    {
        private object data;

        public Message Build()
        {
            if (this.data == null)
            {
                throw new InvalidMessageException("Message data cannot be null");
            }

            return new Message(this.data);
        }

        public IMessageFactory WithObjectData(object data)
        {
            this.data = data;
            return this;
        }
    }
}
