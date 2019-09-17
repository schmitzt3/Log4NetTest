using log4net;
using Topshelf;

namespace Log4NetTest
{
	public class Log4NetTestServiceManager : ServiceControl
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetTestServiceManager));

		public bool Start(HostControl hostControl)
		{
			Logger.Debug("Started service.");
			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			Logger.Debug("Stopped service.");
			return true;
		}
	}
}
