using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMemberConfigurationExpression<TSource, TDestination, TMember> WithMappingOrder<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> expression, int mappingOrder)
        {
            expression.SetMappingOrder(mappingOrder);

            return expression;
        }

        public static IMappingOperationOptions WithIndex(this IMappingOperationOptions options, int index)
        {
            options.Items.Add("Index", index);

            return options;
        }

        public static int GetIndex(this IMappingOperationOptions options)
        {
            object index;
            if (options.Items.TryGetValue("Index", out index) && index is int)
                return (int)index;

            return 0;
        }
    }
}