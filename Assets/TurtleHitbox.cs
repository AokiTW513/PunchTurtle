using System.Collections;
using UnityEngine;

public class TurtleHitbox : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sprite;

    private bool cannotPush;
    [SerializeField] private float cannotPushTime;

    private void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        cannotPush = false;
    }

    public void Push(GameObject obj, float forceX, float forceY)
    {
        if (!cannotPush)
        {
            Vector2 horizontalForce = obj.transform.right * forceX;
            Vector2 verticalForce = Vector2.up * forceY;

            rb2d.AddForce(horizontalForce + verticalForce, ForceMode2D.Impulse);

            spriteRenderer.sprite = sprite;

            cannotPush = true;   
            StartCoroutine(cannotPushTimer());
        }
    }

    IEnumerator cannotPushTimer()
    {
        yield return new WaitForSeconds(cannotPushTime);
        cannotPush = false;   
    }
}