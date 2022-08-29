using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 nextPos;
    // Start is called before the first frame update
    void Start() //might use start
    {
        
    }

    // Update is called once per frame
    
    void Update() //update, and the stuff in it, will eventually be unnecessary 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            agent.SetDestination(new Vector3(0, 0, 5)); //this is the navmesh function to call to set the destination
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Move Point"))
        {
            agent.SetDestination(other.gameObject.GetComponent<MovePointBehavior>().GiveNextPos());//the stuff in setDestination calls the function to give the next position
        }
    }
}
