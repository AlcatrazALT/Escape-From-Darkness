using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float timeToLive;

    void Awake()
    {
        Destroy(gameObject, timeToLive);
    }
}
