﻿namespace PetFoodShop.Data.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        private string serializedData; // Note: this is a field!
        
        public Message(object data)
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
