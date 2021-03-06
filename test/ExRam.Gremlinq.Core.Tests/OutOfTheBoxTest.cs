﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;
using static ExRam.Gremlinq.Core.GremlinQuerySource;

namespace ExRam.Gremlinq.Core.Tests
{
    [UsesVerify]
    public class OutOfTheBoxTest : XunitContextBase
    {
        private class SomeEntity
        {

        }

        public OutOfTheBoxTest(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public async Task Execution()
        {
            g
                .Awaiting(async _ => await _
                    .ConfigureEnvironment(_ => _)
                    .V()
                    .ToArrayAsync())
                .Should()
                .Throw<InvalidOperationException>()
                .Where(x => x.Message.StartsWith("'Execute' must not be called on GremlinQueryExecutor.Invalid"));
        }

        [Fact]
        public async Task V_SomeEntity()
        {
            await g
                .ConfigureEnvironment(e => e
                    .ConfigureSerializer(s => s.ToGroovy())
                    .UseExecutor(GremlinQueryExecutor.Identity)
                    .UseDeserializer(GremlinQueryExecutionResultDeserializer.Identity))
                .V<SomeEntity>()
                .Cast<GroovyGremlinQuery>()
                .Verify(this);
        }
    }
}
