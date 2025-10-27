using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public int speed;
    public Animator anim;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(moveX, moveY).normalized;
        transform.Translate(moveDir * speed * Time.deltaTime);

        if (moveX != 0)
            sprite.flipX = moveX < 0;

        anim.SetBool("isRunning", moveX != 0);
        anim.SetBool("isGoingUp", moveY > 0);
        anim.SetBool("isGoingD", moveY < 0);
    }
}
