using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponManager[] playerWeapons;

    private int weaponIndex;
    [SerializeField]
    private GameObject[] weaponBullets; 
    private Vector2 targetPosition;
    private Vector2 direction;
    private Camera mainCamera;
    private Vector2 bulletSpawnPostion;
    private Quaternion bulletRotation; 
    // [SerializeField]
    // private GameObject bullet;

    private void Awake() {
        weaponIndex = 0; 
        playerWeapons[weaponIndex].gameObject.SetActive(true);
        mainCamera = Camera.main; 
    }

    private void Update() {
        ChangeWeapon(); 
    }

    public void ActivateGun(int gunIndex) {
        playerWeapons[weaponIndex].ActivateGun(gunIndex); 
    }

    void ChangeWeapon() {
        if(Input.GetKeyDown(KeyCode.N))
        {
            // deactivate current weapon
            playerWeapons[weaponIndex].gameObject.SetActive(false);
            weaponIndex++;

            if(weaponIndex == playerWeapons.Length) {
                weaponIndex = 0; 
            }
            // activate new weapon
            playerWeapons[weaponIndex].gameObject.SetActive(true); 
        }
    }

    public void Shoot(Vector3 spawnPosition) {
        targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        bulletSpawnPostion = new Vector2(spawnPosition.x, spawnPosition.y);
        direction = (targetPosition - bulletSpawnPostion).normalized; 

        bulletRotation = Quaternion.Euler(0,0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); 

        GameObject newBullet = Instantiate(weaponBullets[weaponIndex], spawnPosition, bulletRotation);
        newBullet.GetComponent<Projectile>().MoveInDirection(direction);
    }
}
