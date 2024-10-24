using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static string MAIN_MENU_CHARACTER_TAG = "MainMenuCharacter";

    [SerializeField]
    private string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(MAIN_MENU_CHARACTER_TAG)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        }
    }
}
