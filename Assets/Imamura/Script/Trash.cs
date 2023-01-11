using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Trash : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

  
                     // 以下ごみのステータス


    public enum Select_largeCategory
    {
       
        まだ使えるもの,
        生ごみ,
        金属類,
        紙類,
        布類,
        バイオマス類,
        プラスチック,
        ビン類,
        危ないもの類,
        粗大ごみ,
        どうしても燃やさなければならないもの,
        どうしても埋め立てなければならないもの,
        お金がかかるもの,
    }
    public enum Select_SmallCategory
    {

        ______________まだ使えるもの=1000,//マジックナンバー　本当は良くないんだけど数字のダブりを防ぐためにあり得ない数字になってる　なら項目を書くなという話だがあった方が見やすいから仕方ない　待ってろよエディタ拡張
        まだ使えるもの=0,

        ______________生ごみ = 1000,
        生ごみ=10,

        ______________金属類 = 1000,
        アルミ缶      =20,
        スチール缶    =21,
        スプレー缶    =22,
        金属製キャップ=23,
        雑金属        =24,

        ______________紙類 = 1000,
        新聞紙_チラシ    =30,
        段ボール         =31,
        雑誌_雑紙        =32,
        紙パック_白      =33,
        紙パック_銀      =34,
        紙カップ_白      =35,
        硬い紙芯         =36,
        シュレッダーくず =37,
        その他の紙       =38,

        ______________布類 = 1000,
        衣類_毛布   =40,
        その他の布類=41,

        ______________バイオマス類 = 1000,
        割りばし_木竹製品=50,
        廃食油           =51,

        ______________プラスチック = 1000,
        プラスチック製容器包装=60,
        その他のプラスチック  =61,
        白トレイ              =62,
        ペットボトル          =63,
        プラスチック製キャップ=64,

        ______________ビン類 = 1000,
        透明瓶         =70,
        茶色瓶         =71,
        その他の色瓶   =72,
        一升瓶_ビール瓶=73,

        ______________危ないもの類 = 1000,
        ガラス_陶磁器類 =80,
        鏡_水銀体温計   =81,
        電球_蛍光灯     =82,
        乾電池          =83,
        廃バッテリー    =84,
        ライター        =85,

        ______________粗大ごみ = 1000,
        粗大ごみ_金属製                  =90,
        粗大ごみ_木製                    =91,
        粗大ごみ_布団_絨毯_カーペット_畳 =92,
        粗大ごみ_塩ビ製品_ゴミ製品など   =93,

        ______________どうしても燃やさなければならないもの = 1000,
        革製品_ゴム製品_塩ビ製品       =100,
        おむつ_ゴ生理用品_ペットシート =101,

        ______________どうしても埋め立てなければならないもの = 1000,
        どうしても埋め立てなければならないもの=110,

        ______________お金がかかるもの = 1000,
        廃タイヤ=120,
        廃消火器=121,
        特定家電=122

    }


[Header("――――――――――――ごみのステータス―――――――――――")]


    public string Name;


    [Tooltip("大カテゴリ")]
    public Select_largeCategory L_Category;
    [Tooltip("小カテゴリ")]
    public Select_SmallCategory S_Category;


    

    [Tooltip("分解しなければいけないかどうか")]
    public bool NeedDisa;//分解しなければいけないかどうか
    [Tooltip("洗浄しなければいけないかどうか")]
    public bool NeedWash;//洗浄しなければいけないかどうか



    [Tooltip("分解後のパーツ　無ければ何も無し")]
    public GameObject[] Parts;//分解後のパーツ　無ければ何も無し
    [Tooltip("洗浄後の分解後のパーツ　無ければ何も無し")]
    public GameObject[] WashedParts;//洗浄後の分解後のパーツ　無ければ何も無し

    [Tooltip("洗った後の画像 ないのだったらそのままので大丈夫")]
    public Sprite WashedSprite;



    [NonSerialized]
    public bool Disassemblyed;//分解された後かどうか
    [NonSerialized]
    public bool Washed;//洗われた後かどうか

 

    //―――――――――――分解されたオブジェクトの時に使うステータス――――――――――――――

    // [NonSerialized]
    [Tooltip("分解後のパーツの数")]
    public int PartsCount;

   // [NonSerialized]
    [Tooltip("分解後のパーツのうち何番目か")]
    public int PartsNum;




[Header("―――――――――――洗浄前にごみ箱に入れた時の画像―――――――――――")]

    [Tooltip("分解前")]
    public Sprite Before_Dissa;
    [Tooltip("洗浄前")]
    public Sprite Before_Wash;


 //大カテゴリを間違えたときの画像　折りたたんでる
    #region LCategory
    [Header("―――――――――――大カテゴリーを間違えたときの画像―――――――――――")]

    [Tooltip( "まだ使えるもの")]
    public Sprite Miss_Usable;

    [Tooltip( "生ごみ")]
    public Sprite Miss_Garbage;

    [Tooltip( "金属類")]
    public Sprite Miss_metals;


    [Tooltip( "紙類")]
    public Sprite Miss_paper;


    [Tooltip( "布類")]
    public Sprite Miss_cloth;
             

    [Tooltip( "バイオマス類")]
    public Sprite Miss_biomass;
            

    [Tooltip( "プラスチック")]
    public Sprite Miss_plastic;
                
                
    [Tooltip( "ビン類")]
    public Sprite Miss_bottles;
               

    [Tooltip( "危ないもの類")]
    public Sprite Miss_Dangerous;
               

    [Tooltip( "粗大ごみ")]
    public Sprite Miss_Oversized_Garbage;
               

    [Tooltip( "どうしても燃やさなければならないもの")]
    public Sprite Miss_Burnable;
               
               
    [Tooltip( "どうしても埋め立てなければならないもの")]
    public Sprite Miss_landfill;
                

    [Tooltip( "お金がかかるもの")]
    public Sprite Miss_Costs_money;

    #endregion //大カテゴリ
 //大カテゴリを間違えたときの画像　折りたたんでる


[Header("――小カテゴリーを間違えたときの名前と画像 いちいち全部はやってられないので配列にした――")]

    [Tooltip("")]
    public Sprite[] MissImages;

[Header("―――――――――――――――分解後のパーツの目標地点―――――――――――――――")]
    [Tooltip("分解後のパーツの目標地点　パーツの数を設定する")]
     public Vector3[] PartDisaPosi;

    [Tooltip("目標地点　分解移動後に標準に戻すよう")]
   public Vector3  DisaPosi_keep;

    [Header("―――――――――――――――ここから下はいじらないで―――――――――――――――")]
    // 以上ごみのステータス

    [Tooltip("分解の待ち時間")]
    public float DissaTiem;
    [Tooltip("洗浄の待ち時間")]
    public float WashTiem;

    public Vector3 befor_Drag;



    public GameObject Commentary;//間違えたときの解説オブジェクト
   
    GameObject Large_Category;//大カテゴリ
    GameObject Command;//
    GameObject Other;//矢印
    GameObject Standard_Trashs;//通常状態のごみの居場所
    GameObject Ondrag_Trashs;//ドラッグ状態のごみの居場所


    //以下分解洗浄ボタンにかかわる変数
 [NonSerialized]
    public bool CanDiss;
 [NonSerialized]
    public bool CanWash;

    

[NonSerialized]
    Vector3 DisaPosi = new Vector3(775, -68,0);//分解中のポジション
[NonSerialized]
    Vector3 WashPosi = new Vector3(775, 156, 0);//洗浄中のポジション

[NonSerialized]
    Vector3 EndDisaPosi = new Vector3(490, -68,0);//分解後の目標地点
[NonSerialized]
    Vector3 EndWashPosi = new Vector3(490, 156, 0);//洗浄後の目標地点

//[NonSerialized]
    public bool OneTime_Disassemblyed;//分解された後かどうか(一時的)
[NonSerialized]
    public bool OneTime_Washed;//洗浄された後かどうか(一時的)
[NonSerialized]
    private Vector3 velocity = Vector3.zero;//SmoothDampに必要な速度保存用の変数
[NonSerialized]
    private float M_Time = 0.2f;//Small_Categoryの移動時間
[NonSerialized]
    private int dist=1;//Small_Categoryの最大許容距離



    [NonSerialized]
    public int TrueScale=1;//元のサイズ
[NonSerialized]
    public float LargeScale=1.5f;//拡大サイズ


//以下マウスドラッグ用

    Vector2 point;//補正用座標
    private Vector3[] Mouse = new Vector3[2];  //マウスの位置(変化前と現在)
//[NonSerialized]
    public bool CanTrach = false;
    //以下マウスドラッグ用
[Header("――――――――――――――――――――サウンド用――――――――――――――――――――")]
    GameObject SoundManager;//サウンドマネージャー
    public bool WashSound_bool=false;
    public bool DissaSound_bool = false;




    public GameObject NameText;//テスト用にテキスト置き場
    public Text Text;

    //以下テスト用
    public bool Corect;//正誤
    public bool OutingBox=true;
    void Awake()
    {
        DisaPosi_keep = EndDisaPosi;//分解後の移動先の一時避難
    }
    void Start()
    {

        Commentary = transform.parent.parent.transform.GetChild(5).gameObject;
        SoundManager = GameObject.FindWithTag("Sound");
        Large_Category = GameObject.FindWithTag("Large_Category");
        Command = GameObject.FindWithTag("Command");
        Other   = GameObject.FindWithTag("Other");
        Standard_Trashs= GameObject.FindWithTag("Standard_Trashs");
        Ondrag_Trashs = GameObject.FindWithTag("Ondrag_Trashs");
        NameText= GameObject.FindWithTag("Text");
        Text = NameText.GetComponent<Text>();

        Mouse[0] = Input.mousePosition;//mouseの座標の取得
        point = new Vector2(Screen.width / 2, Screen.height / 2);

      

    }

    // Update is called once per frame
    void Update()
    {
　　　//以下分解洗浄フィールドに入れたときに一緒に動く
        if (CanDiss == true)//分解　作動許可
        {
           GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, DisaPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
            CanTrach = false;
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(DisaPosi.x, DisaPosi.y)).magnitude < dist&&CanDiss)//最大許容距離まで到達したら、作動許可取り消し
        {
            
            CanDiss = false;

            DissaSound();//分解サウンド

            if (NeedDisa==false)
            {
                OneTime_Disassemblyed = true;
            }


         
        }

        if (CanWash == true)//洗浄　作動許可
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, WashPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
            CanTrach = false;
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(WashPosi.x, WashPosi.y)).magnitude < dist&& CanWash==true)//最大許容距離まで到達したら、作動許可取り消し
        {
            CanWash = false;



            WashSound();//洗浄サウンド

            StartCoroutine("Wash2");
        }

        //i以上分解洗浄フィールドに入れたときに一緒に動く


        //以下分解洗浄されてオブジェクトが移動した後に作動

        
        if (OneTime_Disassemblyed == true)//作動許可 分解されたオブジェクトが召喚された後
        {
           
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndDisaPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndDisaPosi.x, EndDisaPosi.y)).magnitude < dist)//最大許容距離まで到達したら、作動許可取り消し
        {
            EndDisaPosi = DisaPosi_keep ;
            OneTime_Disassemblyed = false;

        }

        if (OneTime_Washed == true)//作動許可
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndWashPosi, ref velocity, M_Time);//指定の位置まで0.2秒で移動
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndWashPosi.x, EndWashPosi.y)).magnitude < dist)//最大許容距離まで到達したら、作動許可取り消し
        {
            OneTime_Washed = false;

        }

        //以上分解洗浄フィールドに入れたときに一緒に動く



    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        Text.text = Name;
         //SoundManager.GetComponent<SoundManager>().CommandSound_Play();//コマンドサウンド
         befor_Drag = GetComponent<RectTransform>().anchoredPosition;//ドラッグ開始位置の記録
        transform.SetParent(Ondrag_Trashs.transform);
        Mouse[0] = Input.mousePosition;//ドラッグ開始位置を記録
        CanTrach = false;//動いてるごみ箱に入れないようにする
        Other.GetComponent<Other>().TrashDrag = true;//矢印の点滅開始
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        CanTrach = false;


        
        // transform.position = eventData.position;
        // Overlay の場合
        Mouse[1] = Input.mousePosition;//移動後の位置を記録

        if (Mouse[0] != Mouse[1])//食い違ったら差分を移動
        {
            transform.position += (Mouse[1] - Mouse[0]);//差分で移動
            Mouse[0] = Input.mousePosition;//現在位置を記録
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "CategoryBox")//大カテゴリへの接触
        {
            Large_Category.GetComponent<BoxManager>().ReMove();//大カテゴリの箱を初期値に移動
            Large_Category.GetComponent<BoxManager>().BoxChange(collision.gameObject.name);//箱を接触したカテゴリの名前で判定して小カテゴリの変遷
            Large_Category.GetComponent<BoxManager>().Move = true;//小カテゴリの移動
            Large_Category.GetComponent<BoxManager>().Sink = false;//小カテゴリの移動
        }
        if (collision.tag == "Box" && CanTrach == true)//小カテゴリのごみ箱が動作後に当たった時
        {
            if (Corect == false&& CanTrach == false)//正誤判定
            {
                Commentary.SetActive(true);
            }
           
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.tag == "CategoryBox")
        {
            Large_Category.GetComponent<BoxManager>().Move = true;

        }
        if (collision.tag == "Right")//矢印の上
        {
           
            Large_Category.GetComponent<BoxManager>().OnArrow(-1);

        }
        if (collision.tag == "Left")//矢印の上
        {

            Large_Category.GetComponent<BoxManager>().OnArrow(1);

        }
        if (collision.tag == "Box" && CanTrach == true)
        {

            Debug.Log("11111111111111111111111111111");
            Incorrect(collision.gameObject);
          

            //  Large_Category.GetComponent<BoxManager2>().ReMove();

        }

        if (collision.tag == "Disassembly" && CanTrach == true)//  分解ボタンの上でマウスを離す
        {
            Disas();
        }
        if (collision.tag == "Wash" && CanTrach == true)//  洗浄ボタンの上でマウスを離す
        {
            
            Wash();


        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //SoundManager.GetComponent<SoundManager>().CommandSound2_Play();//コマンド２
        transform.SetParent(Standard_Trashs.transform);
        CanTrach = true;
        Other.GetComponent<Other>().TrashDrag = false;//矢印の点滅終了
        transform.localScale = new Vector3(TrueScale, TrueScale, TrueScale);

    }

    public void OnTriggerExit(Collider other)
    {
        OutingBox = true;
        if (other.tag == "Box" )
        {
          
        }

    }

    public void ClickDown()
    {
        Command.GetComponent<Command>().Move = true;
        Command.GetComponent<Command>().Sink = false;
        transform.localScale = new Vector3(LargeScale, LargeScale, LargeScale);
    }
    public void ClickUP()
    {
        Command.GetComponent<Command>().Sink = true;
        Command.GetComponent<Command>().Move = false;

        Large_Category.GetComponent<BoxManager>().Sink = true;
        Large_Category.GetComponent<BoxManager>().Move = false;
        transform.localScale = new Vector3(TrueScale, TrueScale, TrueScale);
    }

    public void ChangeImage()
    {
        
    }


    public void Disas()
    {
        if (NeedDisa)
        {
            DissaSound_bool = true;
        }
        CanDiss = true;
        Disassemblyed = true;
       
        StartCoroutine("Disas_2");//パーツ召喚をコルーチンで起動
        
    }

    public IEnumerator Disas_2()//分解後に作動
    {
        yield return new WaitForSeconds(DissaTiem);

        if (NeedDisa == true)
        {
            
            GameObject[] PObj;//パーツオブジェクトたち
            if (Washed == false)//洗浄前かどうか
            {
                PObj = Parts;
            }
            else
            {
                PObj = WashedParts;
            }

            int num = 1;
            foreach (var obj in PObj)//一個ずつ召喚
            {

                Debug.Log(1);
                GameObject Invited_Parts = Instantiate(obj, DisaPosi, transform.rotation, Standard_Trashs.transform);

                Invited_Parts.GetComponent<RectTransform>().anchoredPosition = DisaPosi;//場所を変更
                Invited_Parts.GetComponent<Trash>().PartsCount = Parts.Length;//パーツ数を変更
                Invited_Parts.GetComponent<Trash>().PartsNum = num;//パーツの中で何番目か
                Invited_Parts.GetComponent<Trash>().ChengeDisaPosi();//召喚されたパーツの行き先を変更
                Invited_Parts.GetComponent<Trash>().OneTime_Disassemblyed = true;//召喚された奴を移動させる
                num++;

            }
            Destroy(this.gameObject);
        }

   
    }

    public void DissaSound()//分解サウンドの設定
    {

        Debug.Log(Conect_LCategory(L_Category.ToString()));
        if (DissaSound_bool)
        {
            if (L_Category.ToString()== "金属類")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_metal_Play();
            }
            if (L_Category.ToString() == "紙類")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_paper_Play();
                StartCoroutine("Paper2");
            }
            if (L_Category.ToString() == "プラスチック")
            {
                SoundManager.GetComponent<SoundManager>().DissaSound_pla_Play();
            }
       



        }
        else
        {
            SoundManager.GetComponent<SoundManager>().Dissa_MissSound_Play();
        }

        DissaSound_bool = false;
    }


    public IEnumerator Paper2()
    {

        yield return new WaitForSeconds(0.5f);
        SoundManager.GetComponent<SoundManager>().DissaSound_paper2_Play();

    }

    public void Wash()
    {
        Debug.Log(CanTrach);
        CanWash = true;//洗浄許可
        Washed = true;//洗浄後

        if (NeedWash == true)
        {
            WashSound_bool = true;
            NeedWash = false;
            this.gameObject.GetComponent<Image>().sprite = WashedSprite;
            Name = "洗われた"+Name;
        }

    }



    public IEnumerator  Wash2()
    {

        yield return new WaitForSeconds(WashTiem);
        OneTime_Washed = true;
    }

    public void WashSound()//洗浄サウンドの設定
    {
        if (WashSound_bool)
        {
            SoundManager.GetComponent<SoundManager>().WashSound_Play();
        }
        else
        {
            SoundManager.GetComponent<SoundManager>().Wash_MissSound_Play();
        }

        WashSound_bool = false;
    }


　public void ChengeDisaPosi()//分解後パーツの行き先を変更
    {
        if (PartsCount==3)//分解後のパーツ数が3つだった場合
        {
            if (PartsNum==1)
            {
                EndDisaPosi = PartDisaPosi[0];
            }
            if (PartsNum == 2)
            {
                EndDisaPosi = PartDisaPosi[1];
            }
            if (PartsNum == 3)
            {
                EndDisaPosi = PartDisaPosi[2];
            }
        }else if (PartsCount==2)
        {
            if (PartsNum == 1)
            {
                EndDisaPosi = PartDisaPosi[0];
            }
            if (PartsNum == 2)
            {
                EndDisaPosi = PartDisaPosi[1];
            }
        }

    }


  public void Incorrect(GameObject obj)
    {
        Debug.Log(L_Category.ToString());
        bool Corect = true;//正誤判定バグった時のためにデフォルトで通過できるようにしておく
        Sprite IncorrectSprite=null;
        if (NeedDisa)//分解の必要性があるとき
        {
            IncorrectSprite = Before_Dissa;
            Corect = false;
        } else if (NeedWash)//洗浄の必要があるとき
        {
            IncorrectSprite = Before_Wash;
            Corect = false;
        } else if (obj.transform.parent.parent.name!= Conect_LCategory(L_Category.ToString()))//大カテゴリが違うとき　親の名前とEnumで判定
        {
            IncorrectSprite = Miss_LCategory(obj.transform.parent.parent.name);
            Corect = false;
        }
        else if(""+((int)S_Category%10)!=obj.name)//ボックスの名前がEnumとかみ合わない場合
        {
            Debug.Log("------------------"+(int)S_Category % 10);
            IncorrectSprite = MissImages[System.Int32.Parse(obj.name)];//ボックスの名前の画像を出す
            Corect = false;
        }

        if (Corect==false) {
            Debug.Log(IncorrectSprite);
            SoundManager.GetComponent<SoundManager>().Incorrect_Play();
            Commentary.GetComponent<Image>().sprite =IncorrectSprite;
            Commentary.SetActive(true);

        }
        else
        {
            SoundManager.GetComponent<SoundManager>().Correct_Play();
            Destroy(this.gameObject);
        }
         GetComponent<RectTransform>().anchoredPosition= befor_Drag ;
    }


    public string Conect_LCategory(string str)//大カテゴリのEnumから対応するはずの親の名前を抜き出す
    {
        switch (str) {
            case "まだ使えるもの":
                return "Usable";

            case "生ごみ":
                return "Garbage";

            case "金属類":
                return "metals";

            case "紙類":
                return "paper";

            case "布類":
                return "cloth";

            case "バイオマス類":
                return "biomass";

            case "プラスチック":
                return "plastic";

            case "ビン類":
                return "bottles";

            case "危ないもの類":
                return "Dangerous";

            case "粗大ごみ":
                return "Oversized_Garbage";

            case "どうしても燃やさなければならないもの":
                return "Burnable";

            case "どうしても埋め立てなければならないもの,":
                return "landfill";

            case "お金がかかるもの":
                return "Costs_money";


        }

        return "";

    }

    public Sprite Miss_LCategory(string str)//ボックスの親の名前から間違えの画像を引っ張る
    {
        switch (str)
        {
            
            case "Usable":
                return Miss_Usable;
            
            case "Garbage":
                return Miss_Garbage;
            
            case "metals":
                return Miss_metals;
            
            case "paper":
                return Miss_paper;
           
            case "cloth":
                return Miss_cloth;
           
            case "biomass":
                return Miss_biomass;
           
            case "plastic":
                return Miss_plastic;
         
            case "bottles":
                return Miss_bottles;
          
            case "Dangerous":
                return Miss_Dangerous;
         
            case "Oversized_Garbage":
                return Miss_Oversized_Garbage;
           
            case "Burnable":
                return Miss_Burnable;
            
            case "landfill":
                return Miss_landfill;
           
            case "Costs_money":
                return Miss_Costs_money;

        }

        return null;

    }

}
