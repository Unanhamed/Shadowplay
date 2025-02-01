using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    gunprops[] guns;

    float moveSpeed = 3;
    bool moveUp;
    bool moveDown;

    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<gunprops>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q);
        if (shoot) { shoot = false; foreach (gunprops gun in guns) { gun.Shoot(); } }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp) { move.y += moveAmount; }
        if (moveDown) { move.y -= moveAmount; }

        pos += move;

        transform.position = pos;
    }

  
  
}
