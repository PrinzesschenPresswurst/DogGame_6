using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotBehavior : MonoBehaviour
{
    [SerializeField] private float tripleShotLifetime = 3f;
    void Start()
    {
        Invoke("SelfDestruct",tripleShotLifetime);
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
