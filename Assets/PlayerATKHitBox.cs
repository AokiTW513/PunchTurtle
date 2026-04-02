using UnityEngine;

public class PlayerATKHitBox : MonoBehaviour
{
    [SerializeField] private float atkForceX;
    [SerializeField] private float atkForceY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<TurtleHitbox>().Push(this.gameObject, atkForceX, atkForceY);
        }   
    }
}