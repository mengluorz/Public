using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 Pos { get { return transform.position; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularDrag = 0f;
        rb.isKinematic = true;
    }
}

