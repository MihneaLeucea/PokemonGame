using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool isMoving = false;
    private Vector2 input;
    public LayerMask solidObjectsLayer;

    [Header("Mobile DPad Support")]
    public DPadController dpad; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            if (dpad != null)
            {
                input = Vector2.zero;
                if (dpad.upPressed) input.y = 1;
                else if (dpad.downPressed) input.y = -1;
                else if (dpad.leftPressed) input.x = -1;
                else if (dpad.rightPressed) input.x = 1;
            }
            else
            { 
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
            }

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                var targetPos = (Vector2)transform.position + input;
                if(IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
                
            }
        }
        
    }

    IEnumerator Move (Vector2 targetPos)
    {
        isMoving = true;
        while((targetPos - (Vector2)transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
