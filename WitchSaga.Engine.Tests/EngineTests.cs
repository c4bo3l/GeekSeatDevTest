using System;
using System.Collections.Generic;
using Xunit;

namespace WitchSaga.Engine.Tests
{
    public class EngineTests : IDisposable
    {
        private IEngine WitchEngine;

        public EngineTests()
        {
            WitchEngine = new Engine();
        }

        public void Dispose()
        {
            if (WitchEngine == null)
            {
                return;
            }

            WitchEngine.Dispose();
            WitchEngine = null;
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        public void GetFibonacciNumberTests(int input, long output)
        {
            Assert.Equal(output, WitchEngine.GetFibonacciNumber(input));
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 4)]
        [InlineData(4, 7)]
        [InlineData(5, 12)]
        [InlineData(6, 20)]
        public void GetTotalDeathTests(int input, long output)
        {
            Assert.Equal(output, WitchEngine.GetTotalDeath(input));
        }

        [Fact]
        public void GetAverageDeathTests()
        {
            Assert.Equal(-1, WitchEngine.GetAverageDeath(null));
            Assert.Equal(-1, WitchEngine.GetAverageDeath(new List<Person>()));

            List<Person> people = new List<Person>()
            {
                new Person{ AgeOfDeath = 10, YearOfDeath = 12 },
                new Person{ AgeOfDeath = 13, YearOfDeath = 17 }
            };
            Assert.Equal(4.5m, WitchEngine.GetAverageDeath(people));

            people = new List<Person>()
            {
                new Person{ AgeOfDeath = 10, YearOfDeath = 10 },
                new Person{ AgeOfDeath = 13, YearOfDeath = 17 }
            };
            Assert.Equal(-1m, WitchEngine.GetAverageDeath(people));

            people = new List<Person>()
            {
                new Person{ AgeOfDeath = 10, YearOfDeath = 12 },
                new Person{ AgeOfDeath = 13, YearOfDeath = 11 }
            };
            Assert.Equal(-1m, WitchEngine.GetAverageDeath(people));

            people = new List<Person>()
            {
                new Person{ AgeOfDeath = 9, YearOfDeath = 13 },
                new Person{ AgeOfDeath = 1, YearOfDeath = 7 },
                new Person{ AgeOfDeath = 4, YearOfDeath = 9 }
            };
            Assert.Equal(13m, WitchEngine.GetAverageDeath(people));
        }
    }
}
