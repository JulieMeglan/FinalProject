using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] guns;

    private int activeGun;

    private void Start(){
        DeactivateAllGuns();
    }
    
    void DeactivateAllGuns() {
        for(int i = 0; i < guns.Length; i++) {
            guns[i].SetActive(false);
        }
    }

    public void ActivateGun(int newGunIndex) {
        guns[activeGun].SetActive(false);
        guns[newGunIndex].SetActive(true);
        activeGun = newGunIndex; 
    }

}


