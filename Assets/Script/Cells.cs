using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    public bool Alive=true;
   [HideInInspector]public int neighbour;
    // Start is called before the first frame update
   
    public  void setlive(bool alive)
    {
        Alive = alive;

        if (alive)
        {
           this.gameObject.SetActive(true);
        }
    }
    public void setDead(bool alive)
    {
        Alive = alive;
        if(!alive)
        {
            this.gameObject.SetActive(false);
        }

    }

}
