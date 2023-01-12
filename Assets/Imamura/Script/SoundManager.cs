using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{

    AudioSource audioSource;

    [Tooltip("�R�}���h�T�E���h")]
    public AudioClip CommandSound;
    [Tooltip("�R�}���h�T�E���h2")]
    public AudioClip CommandSound2;

    [Tooltip("���T�E���h")]
    public AudioClip WashSound;
    [Tooltip("��򎸔s�T�E���h")]
    public AudioClip Wash_MissSound;


    [Tooltip("�����T�E���h_��")]
    public AudioClip DissaSound_paper;
    [Tooltip("�����T�E���h_��2")]
    public AudioClip DissaSound_paper2;

    [Tooltip("�����T�E���h_�v��")]
    public AudioClip DissaSound_pla;
    [Tooltip("�����T�E���h_����")]
    public AudioClip DissaSound_metal;
    [Tooltip("�����T�E���h_���s")]
    public AudioClip Dissa_MissSound;

    [Tooltip("�����T�E���h")]
    public AudioClip Correct;
    [Tooltip("�s�����T�E���h")]
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


    public void CommandSound_Play()//�R�}���h�P
    {
        audioSource.PlayOneShot(CommandSound);
    }
    public void CommandSound2_Play()//�R�}���h2
    {
        audioSource.PlayOneShot(CommandSound2);
    }


    public void WashSound_Play()//���
    {
        audioSource.PlayOneShot(WashSound);
    }
    public void Wash_MissSound_Play()//��򎸔s
    {
        audioSource.PlayOneShot(Wash_MissSound);
    }


    public void DissaSound_paper_Play()//���P
    {
        audioSource.PlayOneShot(DissaSound_paper);
    }
    public void DissaSound_paper2_Play()//��2
    {
        audioSource.PlayOneShot(DissaSound_paper2);
    }
    public void DissaSound_pla_Play()//�v���X�`�b�N
    {
        audioSource.PlayOneShot(DissaSound_pla);
    }
    public void DissaSound_metal_Play()//����
    {
        audioSource.PlayOneShot(DissaSound_metal);
    }
    public void Dissa_MissSound_Play()//�������s
    {
        audioSource.PlayOneShot(Dissa_MissSound);
    }
    public void Correct_Play()//����
    {
        audioSource.PlayOneShot(Correct);
    }
    public void Incorrect_Play()//�s����
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
