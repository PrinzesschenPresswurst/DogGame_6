using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    [SerializeField] private float powerUpLifetime = 3f;
    
    void Start()
    { 
        Invoke("SelfDestruct",powerUpLifetime);
    }
    
    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
