using UnityEngine;

public class PathingParentBehavior : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {

            if (i + 1 < transform.childCount)
            {
                transform.GetChild(i).GetComponent<MovePointBehavior>().nextPosObj =
                    transform.GetChild(i + 1).gameObject;
            }
            else
            {
                transform.GetChild(i).GetComponent<MovePointBehavior>().nextPosObj = transform.GetChild(i).gameObject;
            }
            
            Debug.Log(i);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.GetChild(0).GetComponent<MovePointBehavior>().nextPosObj = transform.GetChild(1).gameObject;
        }
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, 1);
    }
}
