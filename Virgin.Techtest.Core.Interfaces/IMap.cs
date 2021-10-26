using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgin.Techtest.Core.Interfaces
{
    public interface IMap<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }

    public interface IMap<TSource, TDestination, TParam1>
    {
        TDestination Map(TSource source, TParam1 param1);
    }


    public interface IMap<TSource, TDestination, TParam1, TParam2>
    {
        TDestination Map(TSource source, TParam1 param1, TParam2 param2);
    }

    public interface IMap<TSource, TDestination, TParam1, TParam2, TParam3>
    {
        TDestination Map(TSource source, TParam1 param1, TParam2 param2, TParam3 param3);
    }
}
