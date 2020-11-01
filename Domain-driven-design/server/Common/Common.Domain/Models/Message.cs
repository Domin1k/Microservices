namespace PetFoodShop.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Message : IAggregateRoot
    {
        private string serializedData; // Note: this is a field!
        
        internal Message(object data)
        {
            this.Data = data;
        }

        private Message() { }

        public int Id { get; private set; }

        public Type Type { get; private set; }

        public bool Published { get; private set; }

        public Message MarkAsPublished()
        {
            this.Published = true;
            return this;
        }

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(this.serializedData, this.Type, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            set
            {
                this.Type = value?.GetType();
                this.serializedData = JsonConvert.SerializeObject(value, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
