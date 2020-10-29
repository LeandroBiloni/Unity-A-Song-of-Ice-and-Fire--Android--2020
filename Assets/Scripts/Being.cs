using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour, IAbility
{
    public float hp;
    public float maxHP;
    public string element;
    


    public virtual void Start()
    {
        maxHP = hp;
    }
    public virtual void Shoot(string element)
    {
        throw new System.NotImplementedException();
    }

    public virtual void TakeDamage(int damage, string element)
    {
        throw new System.NotImplementedException();
    }
}
