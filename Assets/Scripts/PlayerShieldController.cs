using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private void Start()
    {
        _meshRenderer = shield.GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
        _collider = shield.GetComponent<Collider>();
        _collider.enabled = false;
    }

    public void OnShieldCollected()
    {
        _meshRenderer.enabled = true;
        _collider.enabled = true;
    }

    public void RemoveShield()
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }
}
