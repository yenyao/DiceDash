using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawn : MonoBehaviour
{
    private Spawn spawn;
    public GameObject TileMap;
    void Start() {
        spawn = gameObject.AddComponent(typeof(Spawn)) as Spawn;
        int lastChildIndex = TileMap.transform.childCount - 1;
        transform.position = spawn.spawnPosition(1, TileMap);
    }
}
