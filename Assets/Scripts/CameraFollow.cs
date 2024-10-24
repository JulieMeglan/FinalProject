using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static string PLAYER_TAG = "Player";
    private Transform playerTarget;

    [SerializeField]
    private float bound_x = 0.3f;
    private float bound_y = 0.15f;
    private Vector3 deltaPosition;
    private float deltaX;
    private float deltaY;

    private void Start() {
        playerTarget = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    private void LateUpdate() {
        if(!playerTarget)
            return; 
        
        deltaPosition = Vector3.zero;
        deltaX = playerTarget.position.x - transform.position.x;

        if(deltaX > bound_x || deltaX < - bound_x) {
            if(transform.position.x < playerTarget.position.x){
                deltaPosition.x = deltaX - bound_x;}
            else    deltaPosition.x = deltaX + bound_x; 
        }

        deltaY = playerTarget.position.y - transform.position.y;

        if(deltaY > bound_y || deltaY < - bound_y) {
            if(transform.position.y < playerTarget.position.y){
                deltaPosition.y = deltaY - bound_y;}
            else 
                deltaPosition.y = deltaY + bound_y; 
        }
        
        deltaPosition.z = 0f;
        transform.position += deltaPosition; 
    }
}
