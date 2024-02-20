using System;
namespace Asteroids.Models
{
    [Serializable]
    public class GameConfigData
    {
        public float StartRoundDelaySeconds;
        public PlayerModel Player;
        public AsteroidModel Asteroid;
        public UfoModel Ufo;
    }
}
