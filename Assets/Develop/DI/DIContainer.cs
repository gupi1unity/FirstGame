using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.DI
{
    public class DIContainer
    {
        public readonly Dictionary<Type, Registration> _container = new();

        private readonly DIContainer _parent;

        private readonly List<Type> _requests = new();

        public DIContainer() : this(null)
        {

        }

        public DIContainer(DIContainer parent)
        {
            _parent = parent;
        }

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            if (_container.ContainsKey(typeof(T)))
            {
                throw new System.Exception($"{typeof(T)} Already registered");
            }

            Registration registration = new Registration(creator);
            _container.Add(typeof(T), registration);
        }

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))
            {
                throw new System.Exception($"Cycle resolve for {typeof(T)}");
            }

            _requests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                {
                    return CreateFrom<T>(registration);
                }

                if (_parent != null)
                {
                    return _parent.Resolve<T>();
                }
            }
            finally
            {
                _requests.Remove(typeof(T));
            }

            throw new System.Exception($"Registration for {typeof(T)} not exist");
        }

        private T CreateFrom<T>(Registration registration)
        {
            if (registration.Instance == null && registration.Creator != null)
            {
                registration.Instance = registration.Creator(this);
            }

            return (T)registration.Instance;
        }

        public class Registration
        {
            public Func<DIContainer, object> Creator { get; }
            public object Instance { get; set; }

            public Registration(object instance)
            {
                Instance = instance;
            }

            public Registration(Func<DIContainer, object> creator)
            {
                Creator = creator;
            }
        }
    }
}
