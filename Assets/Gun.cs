using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    gunprops[] guns;

    float moveSpeed = 3;
    bool moveUp;
    bool moveDown;

    bool shoot;
    
    public Animator animator;

    public int MaxBullets;
    
    public int bulletsRemain = 6;
    
    public Image[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<gunprops>();
        MaxBullets = bullets.Length;
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q);
        if (shoot) { 
            shoot = false;
            if(bulletsRemain > 0)
            {
                LoseBullet();
                animator.SetTrigger("Shot"); 
                foreach (gunprops gun in guns) { gun.Shoot(); }
                
            }
            else
            {
                animator.SetTrigger("Reload");
                StartCoroutine(WaitAndPrint());
                bulletsRemain = MaxBullets;
            }
        }
    }
    
    IEnumerator WaitAndPrint()
    {
        foreach (var img in bullets)
        {
            yield return new WaitForSeconds(0.2f);
            img.enabled = true;
        }
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

    public void LoseBullet()
    {
        bulletsRemain--;
        bullets[bulletsRemain].enabled = false;
        
    }

  
  
}
