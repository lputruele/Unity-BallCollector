using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

namespace Game.Level
{

    public class ItemSpawner : MonoBehaviour
    {
        public GameObject eggPrefab;
        public GameObject bombPrefab;
        private List<GameObject> _spawnList = new List<GameObject>();
        private const int _capacity = 5;
        public PositionType position;


        public void Spawn(bool egg)
        {
            GameObject spawn = Instantiate(egg ? eggPrefab : bombPrefab, transform.position, transform.rotation);
            Item item = spawn.GetComponent<Item>();
            Assert.IsNotNull(item);
            item.position = position;
            item.isBomb = !egg;
            _spawnList.Add(spawn);
        }

        private void Update()
        {
            if (_spawnList.Count > _capacity)
            {
                GameObject toBeDestroyed = _spawnList[0];
                _spawnList.RemoveAt(0);
                Destroy(toBeDestroyed);
            }
        }
    }
}