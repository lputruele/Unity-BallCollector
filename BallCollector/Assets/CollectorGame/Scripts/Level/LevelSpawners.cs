using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Level
{
    public class LevelSpawners : MonoBehaviour
    {
        public ItemSpawner[] spawners;
        private int frameCounter;
        [SerializeField]
        [Tooltip("Frames between waves of dropping items")]
        private int spawnTimer = 100;
        [SerializeField]
        [Tooltip("Probability of spawning item at a given spawner")]
        private float spawnProbability = 0.1f;
        [SerializeField]
        [Tooltip("Probability of item being a good one")]
        private float eggProbability = 0.7f;

        void Start()
        {
            spawners = GetComponentsInChildren<ItemSpawner>();
            frameCounter = 0;
        }

        // Manage item spawners
        void Update()
        {
            if (frameCounter == 0)
            {
                for (int i = 0; i < spawners.Length; i++)
                {
                    float spawnProb = Random.Range(0.0f, 1.0f);
                    float eggProb = Random.Range(0.0f, 1.0f);
                    if (spawnProb < spawnProbability)
                    {
                        // Spawn an Egg or a Bomb
                        spawners[i].Spawn(eggProb < eggProbability);
                        break;
                    }              
                }
            }
            frameCounter++;
            frameCounter %= spawnTimer;
        }
    }

}
