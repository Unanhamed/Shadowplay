using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunprops : MonoBehaviour
{
    public Bullet bullet;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)

            {
                if (shootTimer >= shootIntervalSeconds) { Shoot(); shootTimer = 0; }
                else { shootTimer += Time.deltaTime; }
            }
            else { delayTimer += Time.deltaTime; }
        }
        
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
    }
}
