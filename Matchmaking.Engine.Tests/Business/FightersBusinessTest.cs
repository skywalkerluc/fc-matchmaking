using Matchmaking.Engine.Business;
using Matchmaking.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Matchmaking.Engine.Tests.Business
{
    public class FightersBusinessTest
    {
        private readonly FightersBusiness _fightersBusiness;

        public FightersBusinessTest()
        {
            _fightersBusiness = new FightersBusiness();
        }

        [Fact]
        public void ShouldReturnFighterCollection()
        {
            var result = _fightersBusiness.GetFighters();
            Assert.True(result is IEnumerable<Fighter>);
        }
    }
}
