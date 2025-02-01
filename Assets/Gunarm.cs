using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunarm : MonoBehaviour
{
    float moveSpeed = 3.5f;
    bool moveUp;
    bool moveDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
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
