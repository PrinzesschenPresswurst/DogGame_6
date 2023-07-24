using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField] private float laserMoveSpeed = 10f;
    [SerializeField] private float destructionDistanceY = 6.1f;

    void Update()
    {
        MoveLaser();
        DestroyLaserAfterLeavingScreen();
    }

    private void MoveLaser()
    {
        float laserMoveSpeedFactor = laserMoveSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * laserMoveSpeedFactor);
    }
    
    private void DestroyLaserAfterLeavingScreen()
    {
        if (transform.position.y >= destructionDistanceY)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
            Destroy(this.gameObject);
        }
    }
}
