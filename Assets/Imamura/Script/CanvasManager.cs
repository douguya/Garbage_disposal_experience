using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            c1view();
        }
        if (Input.GetKeyDown("2"))
        {
            c2view();
        }
        if (Input.GetKeyDown("3"))
        {
            c3view();
        }
    }

    public void c1view()
    {
        c1.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);

    }
    public void c2view()
    {
        c1.SetActive(false);
        c2.SetActive(true);
        c3.SetActive(false);

    }
    public void c3view()
    {
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(true);

    }
}
