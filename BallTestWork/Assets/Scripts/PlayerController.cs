using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnFinish();
    public delegate void OnDestroy();

    public event OnFinish onFinish;
    public event OnDestroy onDestroy;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))/100, ForceMode.Impulse);
        if(this.transform.position.y < -5)
        {
            onDestroy?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            onFinish?.Invoke();
        }
    }
}
