using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovePointBehavior : MonoBehaviour
{
    public Vector3 nextPos;
    public GameObject nextPosObj;
    void Start()
    {
        nextPos = nextPosObj.gameObject.transform.position;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
    }

    public Vector3 GiveNextPos()
    {
        return nextPos;
    }
}
