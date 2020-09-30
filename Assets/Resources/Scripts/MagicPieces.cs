using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPieces : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private Vector3 direction;
    public float speed;

    void Update()
    {
        direction = Vector3.right;
        direction*=speed;
        rigidbody.velocity = direction;

        Destroy(gameObject,6);
    }
}
