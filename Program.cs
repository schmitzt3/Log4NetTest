using Autofac;
using Log4NetTest.Autofac;
using Microsoft.Extensions.Logging;
using Topshelf;

namespace Log4NetTest
{
	internal class Program
	{
		private static void Main()
		{
			HostFactory.Run(configurator =>
			{
				configurator.Service<Log4NetTestServiceManager>(settings =>
				{
					settings.ConstructUsing(() =>
					{
						var containerBuilder = new ContainerBuilder();

						containerBuilder.RegisterModule(new Log4NetTestConfigurationModule());

						var container = containerBuilder.Build();

						return container.Resolve<Log4NetTestServiceManager>();
					});

					settings.WhenStarted((manager, control) => manager.Start(control));
					settings.WhenStopped((manager, control) => manager.Stop(control));
				});

				configurator.RunAsLocalSystem();
				configurator.SetDescription("Test log4net integration");
				configurator.SetDisplayName("Log4NetTest");
				configurator.SetServiceName("Log4NetTest");
			});
		}
	}
}
