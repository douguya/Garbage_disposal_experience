using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Arrow : MonoBehaviour
{
    GameObject Large_Category;
    public bool Right;

    void Start()
    {

        Large_Category = GameObject.FindWithTag("Large_Category");
      
    }


    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Trash")//ñÓàÛÇÃè„
        {
            if (Right)
            {
                Large_Category.GetComponent<BoxManager>().OnArrow(1);
            }else
            {
                Large_Category.GetComponent<BoxManager>().OnArrow(1);
            }
           


        }
       

    }
}
