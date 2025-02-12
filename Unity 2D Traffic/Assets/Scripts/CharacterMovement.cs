using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    private Vector3 direction;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // test the character movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // create normalized vector of the direction
        direction = new Vector3(horizontal, vertical, 0);
        // apply movement to sprite
        AnimateMovement(direction);
    }

    private void FixedUpdate()
    {
        // move the player
        transform.position += direction * speed * Time.deltaTime;
    }
    void AnimateMovement(Vector3 dir)
    {
        if (animator != null)
        {
            if (dir.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", dir.x);
                animator.SetFloat("vertical", dir.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
