using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static string ENEMY_TAG = "Enemy";
    public static string SHOOTER_ENEMY_TAG = "ShooterEnemy";
    public static string BOSS_TAG = "Boss";
    public static string BLOCKING_TAG = "Blocking";

    private Rigidbody2D myBody;

    [SerializeField]
    private float moveSpeed = 2.5f;

    [SerializeField]
    private float damageAmount = 20f;

    private bool dealtDamage;
    [SerializeField]
    private float deactivateTimer = 3f;
    [SerializeField]
    private bool destroyObj; 

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        Invoke("DeactivateBullet", deactivateTimer);
    }

    public void MoveInDirection(Vector3 direction) {
        myBody.velocity = direction * moveSpeed;
    }

    void DeactivateBullet(){
        if(destroyObj) {
            Destroy(gameObject);
        }
        else {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(ENEMY_TAG) || collision.CompareTag(SHOOTER_ENEMY_TAG) || collision.CompareTag(BOSS_TAG)) {

        }
    

        if(collision.CompareTag(BLOCKING_TAG)) {
            
        }
    }

}
