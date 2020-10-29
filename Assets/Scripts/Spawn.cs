using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public GameObject enemiesContainer;
    public Dragon fireDrag;
    public Dragon iceDrag;
    public Dragon finalDrag;

    private void Start()
    {

    }

    public void SpawnDragon(int type)
    {
        switch (type)
        {
            case 1:
                Dragon fire = Instantiate(fireDrag, gameObject.transform, false);
                fire.transform.localPosition = Vector3.zero;
                fire.transform.parent = enemiesContainer.transform;
                break;

            case 2:
                Dragon ice = Instantiate(iceDrag, gameObject.transform, false);
                ice.transform.localPosition = Vector3.zero;
                ice.transform.parent = enemiesContainer.transform;
                break;

            case 3:
                Dragon boss = Instantiate(finalDrag, gameObject.transform, false);
                boss.transform.localPosition = Vector3.zero;
                boss.transform.parent = enemiesContainer.transform;
                break;
        }
    }
}
