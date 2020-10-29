using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed;
    public string element;
    public int damage;
    public AudioSource audioSource;
    public virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Dragon") || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("choqueee");
            DoDamage(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Limit"))
            Destroy(gameObject);
    }
    public void DoDamage(GameObject collided)
    {
        if (collided.gameObject.layer == LayerMask.NameToLayer("Dragon"))
        {
            var enemy = collided.GetComponent<Dragon>();
            enemy.TakeDamage(damage, element);
        }

        if (collided.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var enemy = collided.GetComponent<Player>();
            enemy.TakeDamage(damage, element);
        }
    }
}
