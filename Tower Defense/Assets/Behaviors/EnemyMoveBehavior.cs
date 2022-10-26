using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMoveBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 nextPos;
    public EnemySO StatValues;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (StatValues != null)
        {
            agent.speed = StatValues.speed;
        }
    }

    void Update() //update, and the stuff in it, will eventually be unnecessary 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetAgentDestination(new Vector3(0, 0, 5));
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Move Point"))
        {
            SetAgentDestination(other.gameObject.GetComponent<MovePointBehavior>().GiveNextPos());//the stuff in SetAgentDestination calls the function to give the next position
        }
    }

    public void SetAgentDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
    }
}
