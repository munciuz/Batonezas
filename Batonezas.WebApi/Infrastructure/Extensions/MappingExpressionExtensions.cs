using System;
using System.Linq.Expressions;
using AutoMapper;

namespace Batonezas.WebApi.Infrastructure.Extensions
{
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TDestination, object>> destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, x => x.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression, string destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, x => x.Ignore());
        }
    }
}