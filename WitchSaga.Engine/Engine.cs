using System;
using System.Collections.Generic;

namespace WitchSaga.Engine
{
    public class Engine : IEngine
    {
        private Dictionary<int, long> mDictFibbonaci;
        private Dictionary<int, long> mDictTotalDeath;

        private bool mIsDisposed;

        public Engine()
        {
            mDictFibbonaci = new Dictionary<int, long>();
            mDictTotalDeath = new Dictionary<int, long>();

            mIsDisposed = false;

            Init();
        }

        private void Init()
        {
            mDictFibbonaci.Add(1, 1);
            mDictFibbonaci.Add(2, 1);
            mDictFibbonaci.Add(3, 2);

            mDictTotalDeath.Add(1, 1);
            mDictTotalDeath.Add(2, 2);
            mDictTotalDeath.Add(3, 4);
        }

        public long GetFibonacciNumber(int n)
        {
            if (n <= 0)
            {
                return -1;
            }

            if (!mDictFibbonaci.ContainsKey(n))
            {
                mDictFibbonaci.Add(n, GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2));
            }

            return mDictFibbonaci[n];
        }

        public long GetTotalDeath(int n)
        {
            if (n <= 0)
            {
                return -1;
            }

            if (!mDictTotalDeath.ContainsKey(n))
            {
                long fibonacciNumber = GetFibonacciNumber(n);
                if (fibonacciNumber == -1)
                {
                    return -1;
                }
                mDictTotalDeath.Add(n, fibonacciNumber + GetTotalDeath(n - 1));
            }

            return mDictTotalDeath[n];
        }

        public decimal GetAverageDeath(ICollection<Person> people)
        {
            if (people == null || people.Count <= 0)
            {
                return -1;
            }

            long total = 0;
            long count = 0;

            foreach (Person person in people)
            {
                long totalDeath = GetTotalDeath(person.YearOfDeath - person.AgeOfDeath);

                if (totalDeath <= 0)
                {
                    return -1;
                }

                total += totalDeath;
                ++count;
            }

            return (decimal)total / count;
        }

        public void Dispose()
        {
            if (mIsDisposed)
            {
                return;
            }

            mDictFibbonaci.Clear();
            mDictFibbonaci = null;

            mDictTotalDeath.Clear();
            mDictTotalDeath = null;

            GC.SuppressFinalize(this);
            mIsDisposed = true;
        }
    }
}
