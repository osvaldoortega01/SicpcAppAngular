﻿using SicpcAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using SICPC_API.Entities.Models;

namespace SicpcAPI.Repository
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        public SicpcContext context;

        public Repository(SicpcContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public T Agregar(T objeto)
        {
            typeof(T).GetProperties().ToList().ForEach(propertyInfo =>
            {
                if ((propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System.")) ||
                     propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    propertyInfo.SetValue(objeto, null);
                }
            });

            context.Set<T>().Add(objeto);
            context.SaveChanges();

            context.Entry(objeto).State = EntityState.Detached;
            context.SaveChanges();
            return objeto;
        }

        public void Editar(T objeto)
        {
            typeof(T).GetProperties().ToList().ForEach(propertyInfo =>
            {
                if ((propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System.")) ||
                     propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    propertyInfo.SetValue(objeto, null);
                }
            });

            context.Set<T>().Attach(objeto);
            context.Entry(objeto).State = EntityState.Modified;
            context.SaveChanges();

            context.Entry(objeto).State = EntityState.Detached;
            context.SaveChanges();
        }

        public void Eliminar(T objeto)
        {
            typeof(T).GetProperties().ToList().ForEach(propertyInfo =>
            {
                if ((propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System.")) ||
                     propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    propertyInfo.SetValue(objeto, null);
                }
            });

            context.Remove(objeto);
            context.SaveChanges();
        }

        public void Eliminar(IEnumerable<T> objetos)
        {
            foreach (T objeto in objetos)
            {
                Eliminar(objeto);
            }
        }

        public void Editar(IEnumerable<T> objetos)
        {
            foreach (T objeto in objetos)
            {
                typeof(T).GetProperties().ToList().ForEach(propertyInfo =>
                {
                    if ((propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System.")) ||
                         propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        propertyInfo.SetValue(objeto, null);
                    }
                });

                context.Set<T>().Attach(objeto);
                context.Entry(objeto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Agregar(IEnumerable<T> objetos)
        {
            foreach (T objeto in objetos)
            {
                typeof(T).GetProperties().ToList().ForEach(propertyInfo =>
                {
                    if ((propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.FullName.StartsWith("System.")) ||
                         propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        propertyInfo.SetValue(objeto, null);
                    }
                });

                context.Set<T>().Add(objeto);

            }

            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

    }
}
