using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BoxManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject[] Small_Category_Boxs;
    private Vector3[] Mouse = new Vector3[2];  //マウスの位置(変化前と現在)
    public GameObject Large_Category;
    public GameObject Small_Category; //細かいごみ箱のまとまり 下から湧いて出る
    public bool Move = false;//Small_Categoryを動かすためのトリガー
    public bool Sink = false;//Small_Categoryを反対に動かすためのトリガー

    private Vector2 StartPosi= new Vector2(0, -449);//Small_Categoryの初期位置
    private Vector3 EndPosi = new Vector3(0, -20, 0);//Small_Categoryの最終位置
    private Vector3 velocity = Vector3.zero;//SmoothDampに必要な速度保存用の変数
    private float M_Time = 0.2f;//Small_Categoryの移動時間
    private int dist;//Small_Categoryの最大許容距離

    private int Max  =  635;//大カテゴリの左移動上限
    private int mini = -661;//大カテゴリの右移動上限

    public bool A=false;
    public float B =0;

    public float MoveCoefficient;//ごみが矢印の上にある時の移動寮
    // Start is called before the first frame update

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Move == true)//作動許可
        {
            Small_Category.GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(Small_Category.GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((Small_Category.GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            Move = false;

        }
        if (Sink == true)//作動許可
        {
            Small_Category.GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(Small_Category.GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((Small_Category.GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist)////Small_Categoryの最大許容距離まで到達したら、作動許可取り消し
        {
            Sink = false;

        }


    }


    public void ReMove()
    {
        Small_Category.GetComponent<RectTransform>().anchoredPosition = StartPosi;// Small_Categoryの位置を初期化
        Move = false;
    }





    public void OnBeginDrag(PointerEventData eventData)//ドラッグ開始
    {
        Mouse[0] = Input.mousePosition;//ドラッグ開始位置を記録

    }

    public void OnDrag(PointerEventData eventData)//ドラッグ中
    {
        // transform.position = eventData.position;
        // Overlay の場合
        Mouse[1] = Input.mousePosition;//移動後の位置を記録

        if (Mouse[0] != Mouse[1])//食い違ったら差分を移動
        {
            var rect = Large_Category. GetComponent<RectTransform>().anchoredPosition;//判定用の一時保存
            var MouseAmount = Mouse[1].x - Mouse[0].x;//判定用の移動量

            if ((rect.x + MouseAmount < Max || MouseAmount < 0) && (rect.x + MouseAmount > mini || MouseAmount > 0))//方向と、移動した後に条件に引っ掛かるかで判定
            {
                if (Mathf.Abs(MouseAmount) > 2)//移動量が一定以上の場合
                {
                    MouseAmount = MouseAmount / Mathf.Abs(MouseAmount);//移動量を1に制限
                }
                Large_Category. transform.position += new Vector3(Mouse[1].x - Mouse[0].x, 0, 0);//大カテゴリのスライド
            }
            else
            {

            }

            Mouse[0] = Input.mousePosition;//今回の一を記録
        }

    }


    public void OnEndDrag(PointerEventData eventData)//ドラッグ終わり
    {

    }
   public void OnArrow(int Operator)//右だったら1左だったら―1
    {
        var rect = Large_Category. GetComponent<RectTransform>().anchoredPosition;//判定用の一時保存

        B = MoveCoefficient;
        if ((rect.x + MoveCoefficient * Operator < Max || MoveCoefficient * Operator < 0) && (rect.x + MoveCoefficient * Operator > mini || MoveCoefficient * Operator > 0))//方向と、移動した後に条件に引っ掛かるかで判定
        {
            A = true;
            Large_Category. transform.position += new Vector3(MoveCoefficient* Operator, 0, 0);//大カテゴリのスライド
        }
        else
        {
            A =false;
        }

   
    }

    public void BoxChange(string name)
    {

        for (int loop = 0; loop < Small_Category_Boxs.Length; loop++)//指定があったもの以外を非表示
        {
            if (Small_Category_Boxs[loop].name != name)
            {
                Small_Category_Boxs[loop].SetActive(false);
            }
            else
            {
                Small_Category_Boxs[loop].SetActive(true);
            }
        }
    }


}


