namespace SilverlightBoids.Web.RedisDal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Boids.Core;

    using ServiceStack.Redis;

    public static class ScenarioRepository
    {
        public static long Save(SavedScenario scenario)
        {
            var redisManager = RedisDal.GetClient();

            redisManager.ExecAs<SavedScenario>(redisProject =>
            {
                if (scenario.Id <= 0)
                {
                    scenario.Id = redisProject.GetNextSequence();
                }
                redisProject.Store(scenario);
            });

            return scenario.Id;
        }

        public static SavedScenario Get(long Id)
        {
            //Thread-safe client factory
            var redisManager = RedisDal.GetClient();
            SavedScenario scenario = null;

            redisManager.ExecAs<SavedScenario>(redisProject =>
                                                      {
                                                          scenario = redisProject.GetById(Id);
                                                      });
            return scenario;
        }

        public static List<SavedScenario> GetAll()
        {
            var redisManager = RedisDal.GetClient();
            IList<SavedScenario> scenarios = null;

            redisManager.ExecAs<SavedScenario>(redisProject =>
                                                      {
                                                          scenarios = redisProject.GetAll();
                                                      });

            return (List<SavedScenario>)scenarios;
        }

        public static void Remove(long Id)
        {
            var redisManager = RedisDal.GetClient();

            redisManager.ExecAs<SavedScenario>(redisProject => redisProject.DeleteById(Id));
        }
    }
}