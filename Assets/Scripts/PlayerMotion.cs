using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : CharacterMotion
{
    public static string FACE_X_ANIMATION_PARAMETER = "FaceX";
    public static string FACE_Y_ANIMATION_PARAMETER = "FaceY";

    public static string HORIZONTAL_AXIS = "Horizontal";
    public static string VERTICAL_AXIS = "Vertical";
    private float moveX;
    private float moveY;
    private Camera mainCam;
    private Vector2 mousePosition;
    private Vector2 direction;
    private Vector3 tempScale;
    private Animator anim; 
    private PlayerWeaponManager playerWeaponManager;
    
    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;
        anim = GetComponent<Animator>();
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
    }

    private void FixedUpdate() {
        moveX = Input.GetAxisRaw(HORIZONTAL_AXIS);
        moveY = Input.GetAxisRaw(VERTICAL_AXIS);
        HandlePlayerTurning();

        HandleMovement(moveX, moveY);
    }
    void HandlePlayerTurning() {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized; 
        HandlePlayerAnimation(direction.x, direction.y);

    }
    void HandlePlayerAnimation(float x, float y) {
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);
        // could probs delete below until x = Mathf.Abs
        tempScale = transform.localScale;
        
        if(x > 0)
            tempScale.x = Mathf.Abs(tempScale.x);
        else if (x < 0)
            tempScale.x = -Mathf.Abs(tempScale.x);

        transform.localScale = tempScale; 

        x = Mathf.Abs(x);

        anim.SetFloat(FACE_X_ANIMATION_PARAMETER, x);
        anim.SetFloat(FACE_Y_ANIMATION_PARAMETER, y);

        ActivateWeaponForSide(x, y); 
    }

    void ActivateWeaponForSide(float x, float y) {
    string key = $"{x},{y}";

    switch (key) {
        case "1,0":
            playerWeaponManager.ActivateGun(0); // side
            break;
        case "0,1":
            playerWeaponManager.ActivateGun(1); // up
            break;
        case "0,-1":
            playerWeaponManager.ActivateGun(2); // down
            break;
        case "1,1":
            playerWeaponManager.ActivateGun(3); // side up
            break;
        case "1,-1":
            playerWeaponManager.ActivateGun(4); // side down
            break;
        default:
            playerWeaponManager.ActivateGun(1); // exceptions/default = up
            break;
        }
    }
}
