using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dragon : Being
{
    public AudioSource audioSource;
    public AudioClip flyClip;
    public GameManager manager;
    public Projectile fireball;
    public Projectile iceball;
    public GameObject player;
    public SkinnedMeshRenderer render;
    private float _attackTime;
    private float _time;
    public GameObject projectileSpawn;
    private bool _canShoot;
    public int minShootRandom;
    public int maxShootRandom;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        manager = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        _attackTime = Random.Range(minShootRandom, maxShootRandom);
        _canShoot = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.LookAt(player.transform.position);
        transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);
        if (_canShoot == false)
            AttackTimer();
        else Shoot(element);
    }

    public virtual void AttackTimer()
    {
        _time += Time.deltaTime;
        if (_time >= _attackTime)
        {
            _canShoot = true;
            _time = 0;
            _attackTime = Random.Range(minShootRandom, maxShootRandom);
        }
    }

    public override void TakeDamage(int damage, string receivedElement)
    {
        if (receivedElement == element)
            hp -= damage;
        else hp -= damage * 2;

        if (hp <= 0)
        {
            manager.ReduceEnemiesCount();
            Destroy(gameObject);
        }
    }

    public override void Shoot(string element)
    {
        switch (element)
        {
            case "Fire":
                Projectile fire = Instantiate(fireball, projectileSpawn.transform, false);
                fire.transform.localPosition = Vector3.zero;
                break;

            case "Ice":
                Projectile ice = Instantiate(iceball, projectileSpawn.transform, false);
                ice.transform.localPosition = Vector3.zero;
                break;
        }
        _canShoot = false;
    }


    public IEnumerator FlySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(flyClip.length);
        StartCoroutine(FlySound());
    }
}
