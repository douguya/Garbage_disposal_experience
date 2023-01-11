using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{

    AudioSource audioSource;

    [Tooltip("コマンドサウンド")]
    public AudioClip CommandSound;
    [Tooltip("コマンドサウンド2")]
    public AudioClip CommandSound2;

    [Tooltip("洗浄サウンド")]
    public AudioClip WashSound;
    [Tooltip("洗浄失敗サウンド")]
    public AudioClip Wash_MissSound;


    [Tooltip("分解サウンド_紙")]
    public AudioClip DissaSound_paper;
    [Tooltip("分解サウンド_紙2")]
    public AudioClip DissaSound_paper2;

    [Tooltip("分解サウンド_プラ")]
    public AudioClip DissaSound_pla;
    [Tooltip("分解サウンド_金属")]
    public AudioClip DissaSound_metal;
    [Tooltip("分解サウンド_失敗")]
    public AudioClip Dissa_MissSound;

    [Tooltip("正解サウンド")]
    public AudioClip Correct;
    [Tooltip("不正解サウンド")]
    public AudioClip Incorrect;



    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CommandSound_Play()//コマンド１
    {
        audioSource.PlayOneShot(CommandSound);
    }
    public void CommandSound2_Play()//コマンド2
    {
        audioSource.PlayOneShot(CommandSound2);
    }


    public void WashSound_Play()//洗浄
    {
        audioSource.PlayOneShot(WashSound);
    }
    public void Wash_MissSound_Play()//洗浄失敗
    {
        audioSource.PlayOneShot(Wash_MissSound);
    }


    public void DissaSound_paper_Play()//紙１
    {
        audioSource.PlayOneShot(DissaSound_paper);
    }
    public void DissaSound_paper2_Play()//紙2
    {
        audioSource.PlayOneShot(DissaSound_paper2);
    }
    public void DissaSound_pla_Play()//プラスチック
    {
        audioSource.PlayOneShot(DissaSound_pla);
    }
    public void DissaSound_metal_Play()//金属
    {
        audioSource.PlayOneShot(DissaSound_metal);
    }
    public void Dissa_MissSound_Play()//分解失敗
    {
        audioSource.PlayOneShot(Dissa_MissSound);
    }
    public void Correct_Play()//正解
    {
        audioSource.PlayOneShot(Correct);
    }
    public void Incorrect_Play()//不正解
    {
        audioSource.PlayOneShot(Incorrect);
    }




    public void SerectedSound_Play(string Sound_Name)
    {
        Debug.Log(3333333333333333333);
        AudioClip AC =null;

        switch (Sound_Name) {

            case "CommandSound":
                AC = CommandSound;
                break;

            case "CommandSound2":
                AC = CommandSound2;
                break;

            case "WashSound":
                AC = WashSound;
                break;

            case "Wash_MissSound":
                AC = CommandSound;
                break;

            case "DissaSound_paper":
                AC = DissaSound_paper;
                break;

            case "DissaSound_paper2":
                AC = DissaSound_paper2;
                break;

            case "DissaSound_pla":
                AC = DissaSound_pla; ;
                break;


            case "DissaSound_metal":
                AC = DissaSound_metal;
                break;

            case "Dissa_MissSound":
                AC = Dissa_MissSound;
                break;

            case "Correct":
                AC = CommandSound;
                break;

            case "Incorrect":
                AC = Incorrect;
                break;

    
        }






        audioSource.PlayOneShot(AC);

        Debug.Log((AC));
        if (AC== DissaSound_paper)
        {
            Debug.Log(3333333333333333333);
            StartCoroutine("Paper2");
        }



    }

    public IEnumerator Paper2()
    {

        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(DissaSound_paper2);

    }


}
