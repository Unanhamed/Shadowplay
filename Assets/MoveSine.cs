using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSine : MonoBehaviour

{
    float sinCenterY;
    public static float sineMultiplier = 1f;

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
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x);
        pos.y = sinCenterY + sin * sineMultiplier;   
        
        transform.position = pos;   
    }
}
