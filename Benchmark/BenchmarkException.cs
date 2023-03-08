using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [RPlotExporter]
    public class Md5VsSha256
    {
        private IContainer container;
        private int port;
        private HttpClient client;

        [GlobalSetup]
        public void Setup()
        {
            string webPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..");
            DirectoryInfo info = new DirectoryInfo(webPath);
            webPath = info.FullName;
            new ImageFromDockerfileBuilder()
              .WithName("benchmarktest")
              .WithDockerfileDirectory(webPath)
              .WithDockerfile("ExceptionControlFlowBenchmark/Dockerfile")
              .Build()
              .CreateAsync()
              .Wait();

            Console.WriteLine("Done");

            container = new ContainerBuilder()
                .WithImage("benchmarktest")
                .WithPortBinding("80")
                .Build();

            container.StartAsync().Wait();
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();

            client = new HttpClient();
            client.BaseAddress = new Uri($"http://localhost:{port}");
        }

        [Benchmark]
        public byte[] NoExceptions()
        {
            var response = client.GetAsync("/weatherforecast/correct");
        }

        [Benchmark]
        public byte[] Exceptions100Percent()
        {

        }


        [GlobalCleanup()]
        public void Cleanup()
        {

        }
    }
}
