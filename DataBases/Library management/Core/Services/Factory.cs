using System;

namespace Core.Services
{
    public class Factory<TReturnValue> : Interfaces.IFactory<string, Type, TReturnValue>
    {
        // FIELDS
        System.Collections.Generic.IDictionary<string, Type> factory;

        // CONSTRUCTORS
        public Factory()
        {
            factory = new System.Collections.Generic.Dictionary<string, Type>();
        }

        // PROPERTIES
        protected System.Collections.Generic.IDictionary<string, Type> HiddenFactory => factory;

        // METHODS
        public TReturnValue MakeInstance(string key)
        {
            // checks
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (!factory.ContainsKey(key)) throw new InvalidOperationException($"No such key '{key}'");

            // make instance
            return (TReturnValue)Activator.CreateInstance(factory[key]);
        }

        public void Registrate(string key, Type value)
        {
            // checking argument
            // key
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (factory.ContainsKey(key)) throw new InvalidOperationException($"Type by key '{key}' has been already registered");
            // value
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.IsInterface || value.IsAbstract) throw new ArgumentException(nameof(value));

            // adding
            factory.Add(key, value);
        }

        public void UnRegistrate(string key)
        {
            // checking argument
            // key
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (!factory.ContainsKey(key)) throw new InvalidOperationException($"No such key '{key}'");

            // removing 
            factory.Remove(key);
        }
    }
}
