﻿using System.Collections.Generic;

namespace Asteroids.Game
{
    public class AsteroidSimulator : ISimulator
    {
        private const int BulletsLayer = 6;
        private const int BigSize = 120;

        private readonly AsteroidSpawner _spawner;

        public AsteroidSimulator(SpaceField field, AsteroidView asteroidSample)
        {
            _spawner = new AsteroidSpawner(field, asteroidSample);
        }

        public IReadOnlyList<ICollideable> ActiveAsteroids => _spawner.ActiveAsteroids;

        public void HideAll()
        {
            _spawner.HideAll();
        }

        public void StartupSpawn(int count)
        {
            _spawner.StartupSpawn(count);
        }

        public void Simulate(float deltaTime, IReadOnlyList<ICollideable> bullets)
        {
            IReadOnlyList<Asteroid> items = _spawner.ActiveAsteroids;
            foreach (Asteroid asteroid in items)
            {
                asteroid.Move(deltaTime);

                ICollideable hitBullet = asteroid.GetTouch(bullets, BulletsLayer);
                if (hitBullet != null)
                {
                    hitBullet.Collide();
                    if (asteroid.Size == BigSize)
                    {
                        _spawner.SpawnPieces(asteroid.Positon);
                    }
                    asteroid.Destroy();
                }
            }
        }

    }
}