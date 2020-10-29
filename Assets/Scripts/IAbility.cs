using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Shoot(string element);
    void TakeDamage(int damage, string element);
}
