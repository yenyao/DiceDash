using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawn : MonoBehaviour
{
    public GameObject TileMap;
    private float startXPos;
    private float startYPos;
    private float startZPos;
    private int lastChildIndex;
    void Start() {
        lastChildIndex = TileMap.transform.childCount - 1;
        startXPos = TileMap.transform.GetChild(1).transform.position.x;
        startYPos = TileMap.transform.GetChild(1).transform.position.y;
        startZPos = TileMap.transform.GetChild(1).transform.position.z;
        transform.position = new Vector3(startXPos, startYPos + 1, startZPos);
    }


}
