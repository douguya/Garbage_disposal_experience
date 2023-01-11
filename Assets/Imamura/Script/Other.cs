using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other : MonoBehaviour
{
 
    public GameObject Right;
    public GameObject Left;

    private Image ImageRight;
    private Image ImageLeft;

    public Sprite Black;
    public Sprite Red;

    private float TimeCount = 0f;
    public float Limit;

    public bool TrashDrag = false;

    public bool ColorSwitch = true;//true=çïÇ…ïœâªÅ@false=ê‘Ç…ïœâª
    // Start is called before the first frame update
    void Start()
    {
        ImageRight = Right.GetComponent<Image>();
        ImageLeft = Left.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        TimeCount += Time.deltaTime;

        if (TimeCount >= Limit && TrashDrag == true)
        {
            ArrowFlashing();
            TimeCount = 0;
        }


    }

    public void ArrowFlashing()
    {
        if (ColorSwitch)
        {
            ImageRight.sprite = Black;
            ImageLeft.sprite = Black;
        }
        else
        {
            ImageRight.sprite = Red;
            ImageLeft.sprite = Red;
        }
        ColorSwitch = !ColorSwitch;

    }
}


