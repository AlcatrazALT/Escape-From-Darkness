﻿using UnityEngine;

public class FallThrough : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shootable"), LayerMask.NameToLayer("Shootable"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
