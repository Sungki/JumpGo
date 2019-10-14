using UnityEngine;

public class MovableObject : MonoBehaviour
{
    protected float speed = 5f;
    protected Vector3 velocity = Vector3.zero;
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
