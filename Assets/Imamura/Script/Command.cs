using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Command : MonoBehaviour
{
    private Vector2 StartPosi;//Commandyの初期位置
    public  Vector3 EndPosi;//Commandの最終位置
    private Vector3 velocity = Vector3.zero;//SmoothDampに必要な速度保存用の変数
    private float M_Time = 0.2f;//Small_Categoryの移動時間
    private int dist=1;//Small_Categoryの最大許容距離

    GameObject SoundManager;//サウンドマネージャー

    public bool Move = false;//Commandを動かすためのトリガー
    public bool Sink = false;//Commandを反対に動かすためのトリガー
    // Start is called before the first frame update
    void Start()
    {
        StartPosi = GetComponent<RectTransform>().anchoredPosition;


    }

    // Update is called once per frame
    void Update()
    {
        if (Move == true)//作動許可
        {
           GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            Move = false;
        }
        if (Sink == true)//作動許可
        {
          GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            Sink = false;
        }

    }

    public void ReMove()
    {
       
        GetComponent<RectTransform>().anchoredPosition = StartPosi;// Small_Categoryの位置を初期化
        Move = false;
    }
}
