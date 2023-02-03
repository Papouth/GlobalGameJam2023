using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXOptimisation : MonoBehaviour
{
    [SerializeField] private float destroyTimer;

    private void Start()
    {
        Destroy(this, destroyTimer);
    }
}