namespace Boids.Core
{
    /// <summary>
    /// This class should be used to store Redis specific properties that can be 
    /// inherited by other entities 
    /// </summary>
    public class RedisEntity
    {
        public RedisEntity()
        {
            this.Id = -1;
        }

        /// <summary>
        /// Id used by redis dont name it ID beacuse redis doesnt recognise this ;( sad panda
        /// </summary>
        public long Id { get; set; }
    }
}