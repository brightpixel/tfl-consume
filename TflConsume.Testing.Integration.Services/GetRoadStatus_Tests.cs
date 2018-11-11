using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using PowerAssert;
using TflConsume.Models;
using TflConsume.Services;
using Xunit;

namespace TflConsume.Testing.Integration.Services
{
    public class GetRoadStatus_Tests
    {
        private IConfigurationBuilder builder;
        private IConfigurationRoot configuration;

        public GetRoadStatus_Tests()
        {
            builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

        }

        [Fact]
        public void should_getroadstatus_withvalidroadname_and_return_valid_data()
        {
            var actual = RoadService.GetRoadStatus("A2", configuration["appId"], configuration["developerKey"]);

            PAssert.IsTrue(() => actual.GetType() == typeof(RoadRequestResponse));
        }

        [Fact]
        public void should_not_getroadstatus_withvalidroadname_and_return_exception()
        {
            PAssert.Throws<RoadRequestException>(() =>
                RoadService.GetRoadStatus("Z2", configuration["appId"], configuration["developerKey"]));
        }

        [Fact]
        public void should_not_getroadstatus_withinvalidappid_and_return_exception()
        {
            PAssert.Throws<RoadRequestException>(() => RoadService.GetRoadStatus("A2", "xxxxxx", configuration["developerKey"]));
        }

        [Fact]
        public void should_not_getroadstatus_withinvaliddeveloperkey_and_return_exception()
        {
            PAssert.Throws<RoadRequestException>(() => RoadService.GetRoadStatus("A2", configuration["appId"], "xxxxxx"));
        }
    }
}
