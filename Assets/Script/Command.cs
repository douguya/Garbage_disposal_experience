using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Command : MonoBehaviour
{
    private Vector2 StartPosi;//Commandy�̏����ʒu
    public  Vector3 EndPosi;//Command�̍ŏI�ʒu
    private Vector3 velocity = Vector3.zero;//SmoothDamp�ɕK�v�ȑ��x�ۑ��p�̕ϐ�
    private float M_Time = 0.2f;//Small_Category�̈ړ�����
    private int dist=1;//Small_Category�̍ő勖�e����

    GameObject SoundManager;//�T�E���h�}�l�[�W���[

    public bool Move = false;//Command�𓮂������߂̃g���K�[
    public bool Sink = false;//Command�𔽑΂ɓ��������߂̃g���K�[
    // Start is called before the first frame update
    void Start()
    {
        StartPosi = GetComponent<RectTransform>().anchoredPosition;


    }

    // Update is called once per frame
    void Update()
    {
        if (Move == true)//�쓮����
        {
           GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, EndPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(EndPosi.x, EndPosi.y)).magnitude < dist)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            Move = false;
        }
        if (Sink == true)//�쓮����
        {
          GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, StartPosi, ref velocity, M_Time);//�w��̈ʒu�܂�0.2�b�ňړ�
        }
        if ((GetComponent<RectTransform>().anchoredPosition - new Vector2(StartPosi.x, StartPosi.y)).magnitude < dist)////Small_Category�̍ő勖�e�����܂œ��B������A�쓮��������
        {
            Sink = false;
        }

    }

    public void ReMove()
    {
       
        GetComponent<RectTransform>().anchoredPosition = StartPosi;// Small_Category�̈ʒu��������
        Move = false;
    }
}
