using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrag : Dragon
{

    public override void Start()
    {
        base.Start();
        audioSource.clip = flyClip;
        StartCoroutine(FlySound());
        Material[] mats = render.materials;
        element = "Fire";
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = Color.red;
        }
    }
}
