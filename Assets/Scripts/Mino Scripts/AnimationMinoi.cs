using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMinoi : MonoBehaviour
{
    public Animator mino;
    private Rigidbody2D rb;
    public float hf = 0.0f;
    public float speed = 0.0f;
    Vector2 movement;
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hf = this.transform.position.x > 0.01f ? this.transform.position.x : this.transform.position.x < -0.01f ? 1 : 0;
        speed = this.transform.position.y > 0.01f ? this.transform.position.y : this.transform.position.y < -0.01f ? 1 : 0;
        if (this.transform.position.x < -0.01f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        movement = movement.normalized;

        mino.SetFloat("up", hf);
        mino.SetFloat("down", this.transform.position.y);
        mino.SetFloat("speed", speed);
    }
    
}
