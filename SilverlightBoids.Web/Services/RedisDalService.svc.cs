namespace SilverlightBoids.Web.Services
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    using Boids.Core;

    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RedisDalService
    {
        [OperationContract]
        public void SaveScenario(SavedScenario scenario)
        {
            RedisDal.ScenarioRepository.Save(scenario);
        }

        [OperationContract]
        public SavedScenario LoadScenario()
        {
            return RedisDal.ScenarioRepository.GetAll().First();
        }
    }
}
