using Autofac;
using log4net;
using Log4NetTest.Autofac;
using Topshelf;

namespace Log4NetTest
{
	internal class Program
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

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

				configurator.UseLog4Net("log4net.config", true);
				configurator.RunAsLocalSystem();
				configurator.OnException(exception => Logger.Error("An unhandled exception occurred in Log4NetTest: ", exception));
				configurator.SetDescription("Test log4net integration");
				configurator.SetDisplayName("Log4NetTest");
				configurator.SetServiceName("Log4NetTest");

				Logger.Debug("Logging Program - Main");
			});
		}
	}
}
