﻿using System.Reflection;
using ApprovalTests;
using ApprovalTests.Reporters;
using PublicApiGenerator;
using Xunit;

namespace ExRam.Gremlinq.ApprovalTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTests
    {
        [Fact]
        public void Core()
        {
            var publicApi = Assembly.Load("ExRam.Gremlinq.Core").GeneratePublicApi();
            Approvals.Verify(new ApprovalTextWriter(publicApi, "cs"));
        }

        [Fact]
        public void CosmosDb()
        {
            var publicApi = Assembly.Load("ExRam.Gremlinq.Providers.CosmosDb").GeneratePublicApi();
            Approvals.Verify(new ApprovalTextWriter(publicApi, "cs"));
        }

        [Fact]
        public void GremlinServer()
        {
            var publicApi = Assembly.Load("ExRam.Gremlinq.Providers.GremlinServer").GeneratePublicApi();
            Approvals.Verify(new ApprovalTextWriter(publicApi, "cs"));
        }

        [Fact]
        public void Neptune()
        {
            var publicApi = Assembly.Load("ExRam.Gremlinq.Providers.Neptune").GeneratePublicApi();
            Approvals.Verify(new ApprovalTextWriter(publicApi, "cs"));
        }

        [Fact]
        public void WebSocket()
        {
            var publicApi = Assembly.Load("ExRam.Gremlinq.Providers.WebSocket").GeneratePublicApi();
            Approvals.Verify(new ApprovalTextWriter(publicApi, "cs"));
        }
    }
}