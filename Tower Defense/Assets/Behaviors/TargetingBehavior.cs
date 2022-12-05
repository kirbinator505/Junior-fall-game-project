using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(TowerStatBehavior))]
[RequireComponent(typeof(CoroutineBehavior))]
public class TargetingBehavior : MonoBehaviour
{
    public List<GameObject> enteredObjs;
    public GameObject target;
    public int targetLvl;
    public UnityEvent damageEvent;
    public TowerStatBehavior towerStats;
    public CoroutineBehavior firingCoroutine;
    public delegate void TargetDelegate();
    public TargetDelegate targetingDelegate;

    public void Start()
    {
        towerStats = GetComponent<TowerStatBehavior>();
        firingCoroutine = GetComponent<CoroutineBehavior>();
        targetingDelegate = PickFirstTarget;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enteredObjs.Add(other.gameObject);
        }

        targetingDelegate();

        if (firingCoroutine.canRun != true)
        {
            firingCoroutine.canRun = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enteredObjs.Remove(other.gameObject);
        }
        
        targetingDelegate();
        
        if (enteredObjs.Count <= 0)
        {
            firingCoroutine.canRun = false;
            target = null;
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

    public void SetToFirst()
    {
        targetingDelegate = PickFirstTarget;
    }
    
    public void SetToLast()
    {
        targetingDelegate = PickLastTarget;
    }
    
    public void SetToStrong()
    {
        targetingDelegate = PickStrongestTarget;
    }

    public void Damage()
    {
        target.GetComponent<EnemyStatBehavior>().TakeDamage(towerStats.towerBase.damage);
    }
}
