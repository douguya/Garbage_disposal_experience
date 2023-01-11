using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BoxManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject[] Small_Category_Boxs;
    private Vector3[] Mouse = new Vector3[2];  //�}�E�X�̈ʒu(�ω��O�ƌ���)
    public GameObject Large_Category;
    public GameObject Small_Category; //�ׂ������ݔ��̂܂Ƃ܂� ������N���ďo��
    public bool Move = false;//Small_Category�𓮂������߂̃g���K�[
    public bool Sink = false;//Small_Category�𔽑΂ɓ��������߂̃g���K�[

    private Vector2 StartPosi= new Vector2(0, -449);//Small_Category�̏����ʒu
    private Vector3 EndPosi = new Vector3(0, -20, 0);//Small_Category�̍ŏI�ʒu
    private Vector3 velocity = Vector3.zero;//SmoothDamp�ɕK�v�ȑ��x�ۑ��p�̕ϐ�
    private float M_Time = 0.2f;//Small_Category�̈ړ�����
    private int dist;//Small_Category�̍ő勖�e����

    private int Max  =  635;//��J�e�S���̍��ړ����
    private int mini = -661;//��J�e�S���̉E�ړ����

    public bool A=false;
    public float B =0;

    public float MoveCoefficient;//���݂����̏�ɂ��鎞�̈ړ���
    // Start is called before the first frame update

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Move == true)//�쓮����
        {
            Small_Category.GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(Small_Category.GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((Small_Category.GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            Move = false;

        }
        if (Sink == true)//�쓮����
        {
            Small_Category.GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(Small_Category.GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((Small_Category.GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            Sink = false;

        }


    }


    public void ReMove()
    {
        Small_Category.GetComponent<RectTransform>().anchoredPosition = StartPosi;// Small_Category�̈ʒu��������
        Move = false;
    }





    public void OnBeginDrag(PointerEventData eventData)//�h���b�O�J�n
    {
        Mouse[0] = Input.mousePosition;//�h���b�O�J�n�ʒu���L�^

    }

    public void OnDrag(PointerEventData eventData)//�h���b�O��
    {
        // transform.position = eventData.position;
        // Overlay �̏ꍇ
        Mouse[1] = Input.mousePosition;//�ړ���̈ʒu���L�^

        if (Mouse[0] != Mouse[1])//�H��������獷�����ړ�
        {
            var rect = Large_Category. GetComponent<RectTransform>().anchoredPosition;//����p�̈ꎞ�ۑ�
            var MouseAmount = Mouse[1].x - Mouse[0].x;//����p�̈ړ���

            if ((rect.x + MouseAmount < Max || MouseAmount < 0) && (rect.x + MouseAmount > mini || MouseAmount > 0))//�����ƁA�ړ�������ɏ����Ɉ����|���邩�Ŕ���
            {
                if (Mathf.Abs(MouseAmount) > 2)//�ړ��ʂ����ȏ�̏ꍇ
                {
                    MouseAmount = MouseAmount / Mathf.Abs(MouseAmount);//�ړ��ʂ�1�ɐ���
                }
                Large_Category. transform.position += new Vector3(Mouse[1].x - Mouse[0].x, 0, 0);//��J�e�S���̃X���C�h
            }
            else
            {

            }

            Mouse[0] = Input.mousePosition;//����̈���L�^
        }

    }


    public void OnEndDrag(PointerEventData eventData)//�h���b�O�I���
    {

    }
   public void OnArrow(int Operator)//�E��������1����������\1
    {
        var rect = Large_Category. GetComponent<RectTransform>().anchoredPosition;//����p�̈ꎞ�ۑ�

        B = MoveCoefficient;
        if ((rect.x + MoveCoefficient * Operator < Max || MoveCoefficient * Operator < 0) && (rect.x + MoveCoefficient * Operator > mini || MoveCoefficient * Operator > 0))//�����ƁA�ړ�������ɏ����Ɉ����|���邩�Ŕ���
        {
            A = true;
            Large_Category. transform.position += new Vector3(MoveCoefficient* Operator, 0, 0);//��J�e�S���̃X���C�h
        }
        else
        {
            A =false;
        }

   
    }

    public void BoxChange(string name)
    {

        for (int loop = 0; loop < Small_Category_Boxs.Length; loop++)//�w�肪���������̈ȊO���\��
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


