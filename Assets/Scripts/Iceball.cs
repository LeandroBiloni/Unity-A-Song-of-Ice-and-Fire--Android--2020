using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : Projectile
{
    public AudioClip iceClip;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        audioSource.clip = iceClip;
        audioSource.Play();
        element = "Ice";
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }


}
