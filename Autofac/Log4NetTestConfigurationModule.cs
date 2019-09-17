using Autofac;

namespace Log4NetTest.Autofac
{
	public class Log4NetTestConfigurationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Log4NetTestServiceManager>().InstancePerDependency();
		}
	}
}
