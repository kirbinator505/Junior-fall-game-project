using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovePointBehavior : MonoBehaviour
{
    //to be triggered, other object needs a collider and a rigidbody, this object needs a collider with is trigger on
    public Vector3 nextPos;
    public GameObject nextPosObj;
    void Start()
    {
        StartCoroutine(SetNextPos(0.1f));
    }

    IEnumerator SetNextPos(float wait)
    {
        yield return new WaitForSeconds(wait);
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
