using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDrag : Dragon
{
    public override void Start()
    {
        base.Start();
        audioSource.clip = flyClip;
        StartCoroutine(FlySound());
        Material[] mats = render.materials;
        element = "Ice";
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = Color.blue;
        }
    }
}
