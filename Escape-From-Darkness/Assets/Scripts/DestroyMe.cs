using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float timeToLive;
    
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, timeToLive);
    }
}
