using easyar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : Being
{
    public GameObject crosshair;
    public Projectile fireball;
    public Projectile iceball;
    public bool _canTakeDamage;
    public Console console;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _canTakeDamage = true;
        console.AddCommand("Heal", Heal, "Change your health. Introduce an integer number.");
        console.AddCommand("IgnoreDamage", IgnoreDamage, "Player won't receive damage. Parameters: true ; false");
        element = "Fire";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot(string elements)
    {
        switch (element)
        {
            case "Fire":
                Projectile fire = Instantiate(fireball, crosshair.transform, false);
                fire.transform.localPosition = Vector3.zero;
                fire.transform.parent = null;
                break;

            case "Ice":
                Projectile ice = Instantiate(iceball, crosshair.transform, false);
                ice.transform.localPosition = Vector3.zero;
                ice.transform.parent = null;
                break;
        }
    }

    public override void TakeDamage(int damage, string receivedElement)
    {
        if (_canTakeDamage)
        {
            hp -= damage;
            print("me pegaron");
        }
    }

    private void Heal(List<string> data)
    {
        if (data.Count > 0)
        {
            hp += int.Parse(data[0]);
        }
    }

    private void IgnoreDamage(List<string> data)
    {
        if (data.Count > 0)
        {
            if (bool.Parse(data[0]))
                _canTakeDamage = false;
            else _canTakeDamage = true;
        }
    }

}
