using System;
using System.Collections.Generic;
using TinyIoC;

namespace Tiny.DependencyInjection
{
    public class DependencyContainer
        : IDependencyContainer
    {
        private readonly TinyIoCContainer _container = new TinyIoCContainer();

        public DependencyContainer()
        {
            _container.Register<IDependencyContainer>(this);
        }

        public void Register(Type registerType)
        {
            _container.Register(registerType);
        }

        public void Register(Type registerType, Type registerImplementation)
        {
            _container.Register(registerType, registerImplementation);
        }

        public void Register(Type registerType, object instance)
        {
            _container.Register(registerType, instance);
        }

        public void Register(Type registerType, Type registerImplementation, object instance)
        {
            _container.Register(registerType, registerImplementation, instance);
        }

        public void Register<T>() where T : class
        {
            _container.Register<T>();
        }

        public void Register<T, TImplementation>() where T : class where TImplementation : class, T
        {
            _container.Register<T, TImplementation>();
        }

        public void Register<T>(T instance) where T : class
        {
            _container.Register<T>(instance);
        }

        public void Register<T, TImplementation>(TImplementation instance) where T : class where TImplementation : class, T
        {
            _container.Register<T, TImplementation>(instance);
        }

        public void Register(Type registerType, Func<IDependencyContainer, object> factory)
        {
            _container.Register(registerType, (c, npm) => factory.Invoke(this));
        }

        public void Register<T>(Func<IDependencyContainer, T> factory) where T : class
        {
            _container.Register<T>((c, npm) => factory.Invoke(this));
        }

        public void RegisterAll(Type registrationType, IEnumerable<Type> implementationTypes)
        {
            _container.RegisterMultiple(registrationType, implementationTypes);
        }

        public void RegisterAll<T>(IEnumerable<Type> implementationTypes)
        {
            _container.RegisterMultiple<T>(implementationTypes);
        }

        public object Resolve(Type resolveType)
        {
            return _container.Resolve(resolveType);
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<object> ResolveAll(Type resolveType)
        {
            return _container.ResolveAll(resolveType);
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _container.ResolveAll<T>();
        }

        public bool TryResolve(Type resolveType, out object resolvedType)
        {
            return _container.TryResolve(resolveType, out resolvedType);
        }

        public bool TryResolve<T>(out T resolvedType) where T : class
        {
            return _container.TryResolve<T>(out resolvedType);
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}