using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource src;
    public AudioClip src1, src2;

    public void Button1()
    {
        src.clip=src1;
        src.Play();
    }
    public void Button2()
    {
        src.clip = src2;
        src.Play();
    }
}
