using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class DomainServiceLocator
    {
        private static DomainServiceLocator instance;

        public static DomainServiceLocator GetInstance()
        {
            return instance ??= new DomainServiceLocator();
        }

        private readonly Dictionary<Type, Service> serviceDictionary;

        private DomainServiceLocator()
        {
            this.serviceDictionary = new Dictionary<Type, Service>();
        }
        
        public void RegisterController<T>(T service) where T: Service
        {
            Type type = typeof(T);
            this.serviceDictionary.Add(type, service);
        }

        public T GetService<T>() where T: Service
        {
            Type type = typeof(T);

            return (T) this.serviceDictionary[type];
        }

        public void UnRegisterService<T>() where T: Service
        {
            Type type = typeof(T);
            this.serviceDictionary.Remove(type);
        }
        
        public void Clear()
        {
            this.serviceDictionary.Clear();
        }
    }
}
