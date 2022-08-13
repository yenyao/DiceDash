using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Vector3 spawnPosition(int index, GameObject TileMap) {
        float startXPos = TileMap.transform.GetChild(index).transform.position.x;
        float startYPos = TileMap.transform.GetChild(index).transform.position.y;
        float startZPos = TileMap.transform.GetChild(index).transform.position.z;
        return new Vector3(startXPos, startYPos + 1, startZPos);
    }

    public Vector3 randomiseSpawnRotation() {
        return new Vector3(
            gameObject.transform.eulerAngles.x + Random.Range(0, 3) * 90,
            gameObject.transform.eulerAngles.y + Random.Range(0, 3) * 90,
            gameObject.transform.eulerAngles.z + Random.Range(0, 3) * 90
        );
    }
}
