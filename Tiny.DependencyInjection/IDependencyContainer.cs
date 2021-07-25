using System;
using System.Collections.Generic;

namespace Tiny.DependencyInjection
{
    public interface IDependencyContainer
        : IDisposable
    {
        void Register(Type registerType);
        void Register(Type registerType, Type registerImplementation);
        void Register(Type registerType, object instance);
        void Register(Type registerType, Type registerImplementation, object instance);
        void Register<T>() where T : class;
        void Register<T, TImplementation>() where T : class where TImplementation : class, T;
        void Register<T>(T instance) where T : class;
        void Register<T, TImplementation>(TImplementation instance) where T : class where TImplementation : class, T;
        void Register(Type registerType, Func<IDependencyContainer, object> factory);
        void Register<T>(Func<IDependencyContainer, T> factory) where T : class;
        void RegisterAll(Type registrationType, IEnumerable<Type> implementationTypes);
        void RegisterAll<T>(IEnumerable<Type> implementationTypes);

        object Resolve(Type resolveType);
        T Resolve<T>() where T : class;
        IEnumerable<object> ResolveAll(Type resolveType);
        IEnumerable<T> ResolveAll<T>() where T : class;

        bool TryResolve(Type resolveType, out object resolvedType);
        bool TryResolve<T>(out T resolvedType) where T : class;
    }
}