using UnityEngine;

[CreateAssetMenu]
public class EnemySO : ScriptableObject
{
    public int level, health, value; //health will usually be one unless it's a larger enemy
    public float speed;
    public GameObject[] droppedObj;
}
