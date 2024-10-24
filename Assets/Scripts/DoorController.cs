using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static string MAIN_MENU_CHARACTER_TAG = "MainMenuCharacter";
    public static string OPEN_ANIMATION_PARAMETER = "Open";

    [SerializeField]
    private Animator doorAnimatior;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(MAIN_MENU_CHARACTER_TAG)) {
            doorAnimatior.SetBool(OPEN_ANIMATION_PARAMETER, true);
        }
    }
}

