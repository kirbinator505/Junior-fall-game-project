using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TargetingBehavior : MonoBehaviour
{
    public List<GameObject> enteredObjs;
    public GameObject target;
    public int targetLvl;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enteredObjs.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enteredObjs.Remove(other.gameObject);
        }
    }

    public void PickStrongestTarget()
    {
        if (enteredObjs.Count > 0)
        {
            GameObject tempTarget;
            tempTarget = enteredObjs[0];
            for (int i = 0; i < enteredObjs.Count; i++)
            {
                if (enteredObjs[i].GetComponent<EnemyStatBehavior>().lvl >
                    tempTarget.GetComponent<EnemyStatBehavior>().lvl)
                {
                    tempTarget = enteredObjs[i];
                }
            }
            target = tempTarget;
        }
    }
    
    public void PickFirstTarget()
    {
        if (enteredObjs.Count > 0)
        {
            target = enteredObjs[0];
        }
    }

    public void PickLastTarget()
    {
        if (enteredObjs.Count > 0)
        {
            target = enteredObjs[^1];
        }
    }
    //calling the damage dealing function will be handled by a coroutine as soon as I get my tools subrepo working
}
