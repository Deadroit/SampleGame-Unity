using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject TeleTile;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.transform.SetPositionAndRotation(new Vector3(TeleTile.transform.position.x, 1f, TeleTile.transform.position.z), new Quaternion(0,0,0,0));
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
        }
    }
}
