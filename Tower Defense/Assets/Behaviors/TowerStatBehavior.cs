using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(CoroutineBehavior))]
public class TowerStatBehavior : MonoBehaviour
{
    public TowerSO towerBase;
    private SphereCollider rangeSphere;
    private CoroutineBehavior damageController;
    void Start()
    {
        rangeSphere = GetComponent<SphereCollider>();
        damageController = GetComponent<CoroutineBehavior>();
        if (towerBase != null)
        {
            UpdateRange(towerBase.range);
            UpdateROF(towerBase.fireRate);
        }
    }
    
    public void UpdateRange(float range)
    {
        rangeSphere.radius = range;
    }

    public void UpdateROF(float rate)
    {
        damageController.delay = rate;
    }
}
