using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TargetingBehavior : MonoBehaviour
{
    //look into the built in Sort function in unity
    //https://learn.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/language-compilers/use-icomparable-icomparer more advanced comparison functions
    public TowerSO towerBase;
    private SphereCollider rangeSphere;
    void Start()
    {
        rangeSphere = GetComponent<SphereCollider>();
        if (towerBase != null)
        {
            UpdateRange(towerBase.range);
        }
    }
    
    void Update()
    {
        
    }

    public void UpdateRange(float range)
    {
        rangeSphere.radius = range;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        
    }

    //calling the damage dealing function will be handled by a coroutine as soon as I get my tools subrepo working
}
