using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsUI : MonoBehaviour
{
    public Image[] bullets;
    public int bulletsRemain;

    public void LoseLife()
    {
        bulletsRemain--;
        bullets[bulletsRemain].enabled = false;
        
    }

}
