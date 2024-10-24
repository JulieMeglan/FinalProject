using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : MonoBehaviour
{
    [SerializeField]
    private float shootingTimerLimit = 0.2f;
    private float shootingTimer;
    [SerializeField]
    private Transform bulletSpawnPos;
    private PlayerWeaponManager playerWeaponManager; 

    private void Awake() {
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
    }
    private void Update() {
        HandleShooting();
    }

    void HandleShooting() {
        if(Input.GetMouseButtonDown(0)) { // index 0 means left mouse button down 
            if(Time.time > shootingTimer) {
                shootingTimer = Time.time + shootingTimerLimit; //limit how often player can shoot 
                CreateBullet();
            }
        }
    }
    void CreateBullet(){
        playerWeaponManager.Shoot(bulletSpawnPos.position);
    }

}

