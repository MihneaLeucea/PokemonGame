using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask solidObjectsLayer;
    public LayerMask grass;
    private bool isMoving = false;
    private Vector2 input;

    public Animator anim;
    private SpriteRenderer sprite;
    private Transition sceneTransition;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sceneTransition = GameObject.Find("FadeAnimation").GetComponent<Transition>();
    }

    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                Vector2 targetPos = (Vector2)transform.position + input;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }

                if (input.x != 0)
                    sprite.flipX = input.x < 0;

                anim.SetBool("isRunning", input.x != 0);
                anim.SetBool("IsGoingUp", input.y > 0);
                anim.SetBool("IsGoingDown", input.y < 0);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("IsGoingUp", false);
                anim.SetBool("IsGoingDown", false);
            }
        }
    }

    IEnumerator Move(Vector2 targetPos)
    {
        isMoving = true;

        while ((targetPos - (Vector2)transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        CheckForEncounters();
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) == null;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grass) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                sceneTransition.StartTransition();
            }
        }
    }
}