using UnityEngine;

public class TEMPPosTransferTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.GetComponent<MovePointBehavior>().GiveNextPos());
    }
}
