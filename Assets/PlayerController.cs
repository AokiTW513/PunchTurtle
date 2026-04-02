using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerATKHitBoxFlip;
    [SerializeField] private GameObject playerATKHitBox;
    [SerializeField] private float speed;
    [SerializeField] private bool isATK;        
    [SerializeField] private bool isMoving;
    private SpriteRenderer spriteRenderer;
    private Vector2 input = Vector2.zero;
    private Rigidbody2D rb2d;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isATK = false;
        isMoving = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(input != Vector2.zero && !isATK)
        {
            isMoving = true;
            animator.SetBool("isMoving", true);
            Vector2 moveDir = new Vector2(input.x, 0f).normalized;
            rb2d.linearVelocity = new Vector2(moveDir.x * speed, rb2d.linearVelocity.y);
            if(input.x < 0)
            {
                spriteRenderer.flipX = true;
                playerATKHitBoxFlip.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if(input.x > 0)
            {
                spriteRenderer.flipX = false;
                playerATKHitBoxFlip.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            isMoving = false;   
            animator.SetBool("isMoving", false);
        }
    }

    public void OpenHitBox()
    {
        playerATKHitBox.SetActive(true);
    }

    public void OnATKEnd()
    {
        isATK = false; 
        playerATKHitBox.SetActive(false);   
        animator.SetBool("isATK", false);
        Debug.Log("動畫時間結束");
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        input = callbackContext.ReadValue<Vector2>();
    }

    public void OnATK(InputAction.CallbackContext callbackContext)
    {
        if (!isATK)
        {
            isATK = true;
            animator.SetBool("isATK", true);
        }
    }

    public void OnQuit(InputAction.CallbackContext callbackContext)
    {
        Application.Quit();   
    }
}