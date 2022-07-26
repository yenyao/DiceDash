using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 0.8f;
    private bool _isMoving;
    // index:
    // 0: side facing down
    // 1: forward
    // 2: left
    // 3: right
    // 4: back
    // 5: top
    private KeyCode[] sideVal = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};
    void Start() {  
        MapRight();
        MapTop();
        MapForward();
        calcRemainingSides();
    }
    
    void Update()
    {
        if(_isMoving) return;

        if(Input.GetKeyUp(sideVal[2])) Assemble(Vector3.left);
        else if(Input.GetKeyUp(sideVal[3])) Assemble(Vector3.right);
        else if(Input.GetKeyUp(sideVal[1])) Assemble(Vector3.forward);    
        else if(Input.GetKeyUp(sideVal[4])) Assemble(Vector3.back);
    }

    void MapRight() {
        float maxPos = transform.GetChild(0).position.x;
        sideVal[3] = convertSideToAlphaKeyCode(0);
        for(int i = 0; i < 6; i++) {
            if (transform.GetChild(i).position.x > maxPos) {
                maxPos = transform.GetChild(i).position.x;
                sideVal[3] = convertSideToAlphaKeyCode(i);
            }
        }
    }
    void MapTop() {
        float maxPos = transform.GetChild(0).position.y;
        sideVal[5] = convertSideToAlphaKeyCode(0);
        for(int i = 0; i < 6; i++) {
            if (transform.GetChild(i).position.y > maxPos) {
                maxPos = transform.GetChild(i).position.y;
                sideVal[5] = convertSideToAlphaKeyCode(i);
            }
        }
    }
    void MapForward() {
        float maxPos = transform.GetChild(0).position.z;
        sideVal[1] = convertSideToAlphaKeyCode(0);
        for(int i = 0; i < 6; i++) {
            if (transform.GetChild(i).position.z > maxPos) {
                maxPos = transform.GetChild(i).position.z;
                sideVal[1] = convertSideToAlphaKeyCode(i);
            }
        }
    }

    KeyCode convertSideToAlphaKeyCode(int side) {
        return (KeyCode)(Int32.Parse(transform.GetChild(side).name)) + 48;
    }

    void updateOrientation(Vector3 dir)
    {
        switch (dir) {
            case Vector3 v when v.Equals(Vector3.forward):
                sideVal[1] = sideVal[5];
                sideVal[5] = sideVal[4];
                calcRemainingSides();
                break;
            case Vector3 v when v.Equals(Vector3.left):
                sideVal[5] = sideVal[3];
                sideVal[3] = sideVal[0];
                calcRemainingSides();
                break;
            case Vector3 v when v.Equals(Vector3.right):
                sideVal[3] = sideVal[5];
                sideVal[5] = sideVal[2];
                calcRemainingSides();
                break;
            case Vector3 v when v.Equals(Vector3.back):
                sideVal[5] = sideVal[1];
                sideVal[1] = sideVal[0];
                calcRemainingSides();
                break;
            default:
                break;
        }
    }

    // Calc remaining sides by using the enum value of Alpha1-6
    // Uses logic that sum of opposite sides = 7
    // Alpha1 (49) + Alpha6 (54) = 103
    void calcRemainingSides() {
        sideVal[0] = (KeyCode) 103 - (int) sideVal[5];
        sideVal[4] = (KeyCode) 103 - (int) sideVal[1];
        sideVal[2] = (KeyCode) 103 - (int) sideVal[3];
    }

    void Assemble(Vector3 dir) {
        var anchor = transform.position + (Vector3.down + dir);
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
        updateOrientation(dir);
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;
        for(int i = 0; i < (90/_rollSpeed); i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.001f);
        }
        _isMoving = false;
    }
}
