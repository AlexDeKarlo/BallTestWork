using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Destroy(Door);
    }
}
