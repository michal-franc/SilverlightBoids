using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SilverlightBoids.Web.Services
{
    using NLog;

    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoggingService
    {
        public Logger Logger = LogManager.GetCurrentClassLogger();

        [OperationContract]
        public void LogMessage(string message)
        {
            Logger.Info(message);
        }

    }
}
