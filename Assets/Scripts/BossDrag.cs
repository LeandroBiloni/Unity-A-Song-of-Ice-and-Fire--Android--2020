using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrag : Dragon
{
    public AudioClip roarClip;
    public float minChangeTime;
    public float maxChangeTime;
    private float _changeTime;
    private float _timer;
    public float minTeleportTime;
    public float maxTeleportTime;
    private float _teleportTime;
    private float _tpTimer;
    public float minTPPos;
    public float maxTPPos;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Material[] mats = render.materials;
        element = "Fire";
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = Color.red;
        }
        audioSource.clip = roarClip;
        StartCoroutine(RoarSound());
        _changeTime = Random.Range(minChangeTime, maxChangeTime);
        _teleportTime = Random.Range(minTeleportTime, maxTeleportTime);
        manager.bossMaxHP = maxHP;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ChangeTimer();
        TeleportTimer();
        manager.bossCurrentHP = hp;
    }

    private void ChangeElement(string elem)
    {
        if (elem == "Fire")
        {
            Material[] mats = render.materials;
            element = "Ice";
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i].color = Color.blue;
            }
        }
        else
        {
            Material[] mats = render.materials;
            element = "Fire";
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i].color = Color.red;
            }
        }
    }

    private void ChangeTimer()
    {
        _timer += Time.deltaTime;
        if (_timer >= _changeTime)
        {
            ChangeElement(element);
            _changeTime = Random.Range(minChangeTime, maxChangeTime);
            _timer = 0;
        }
    }

    private void Teleport()
    {
        transform.position = new Vector3(Random.Range(minTPPos, maxTPPos), Random.Range(minTPPos, maxTPPos), Random.Range(minTPPos, maxTPPos));
    }

    private void TeleportTimer()
    {
        _tpTimer += Time.deltaTime;
        if (_tpTimer >= _teleportTime)
        {
            Teleport();
            _teleportTime = Random.Range(minTeleportTime, maxTeleportTime);
            _tpTimer = 0;
        }
    }

    IEnumerator RoarSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(roarClip.length);
        audioSource.clip = flyClip;
        StartCoroutine(FlySound());
    }
}
