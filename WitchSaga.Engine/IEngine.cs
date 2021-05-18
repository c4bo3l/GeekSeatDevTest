using System;
using System.Collections.Generic;

namespace WitchSaga.Engine
{
    public interface IEngine : IDisposable
    {
        /// <summary>
        /// Get n-th Fibonacci number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        long GetFibonacciNumber(int n);

        /// <summary>
        /// Get total death in n-th year.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        long GetTotalDeath(int n);

        decimal GetAverageDeath(ICollection<Person> people);
    }
}
