using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    public float moveSpeed = 5;
    public Vector3 target;
    public Color gizmoColor = Color.red;
    
    float sinCenterY;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(new Vector3(target.x, target.y, 0), 0.1f);
    }


    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool hasHit = false;
    
    private void FixedUpdate()
    {
        if (hasHit) return;
        
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x);
        pos.y = sinCenterY + sin;  
        
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z); 
        
        
        if (Mathf.Approximately(transform.position.x, target.x))
        {
            hasHit = true;
        }
    }
}
