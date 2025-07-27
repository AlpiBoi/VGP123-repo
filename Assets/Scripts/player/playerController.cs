using UnityEditor.ShaderGraph;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxis("Horizontal");

        rb.linearVelocityX = hValue * 5f;
    }
}
