using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    public AudioClip fireClip;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        audioSource.clip = fireClip;
        audioSource.Play();
        element = "Fire";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

}
