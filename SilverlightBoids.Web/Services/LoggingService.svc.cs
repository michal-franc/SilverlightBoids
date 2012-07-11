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
        public void Info(string message)
        {
            this.Logger.Info(message);
        }

        [OperationContract]
        public void Error(string message)
        {
            this.Logger.Error(message);
        }

        [OperationContract]
        public void Debug(string message)
        {
            this.Logger.Debug(message);
        }

        [OperationContract]
        public void Warn(string message)
        {
            this.Logger.Warn(message);
        }

        [OperationContract]
        public void Fatal(string message)
        {
            this.Logger.Fatal(message);
        }

        [OperationContract]
        public void Trace(string message)
        {
            this.Logger.Trace(message);
        }
    }
}
