using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [System.Serializable]
    public struct CarSprite
    {
        public Sprite North;
        public Sprite South;
        public Sprite West;
        public Sprite East;
    };

    [SerializeField]
    private float speed;
    private Vector3 direction;
    private SpriteRenderer carSpriteRenderer;
    public CarSprite carSprite;

    private void Awake()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // test the character movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // create normalized vector of the direction
        direction = new Vector3(horizontal, vertical, 0);
    }

    private void FixedUpdate()
    {
        // move the player
        transform.position += direction * speed * Time.deltaTime;
        if (direction.y > 0) // North
        {
            carSpriteRenderer.sprite = carSprite.North;
        } else if (direction.y < 0) // South
        {
            carSpriteRenderer.sprite = carSprite.South;
        } else if (direction.x > 0) // East
        {
            carSpriteRenderer.sprite = carSprite.East;
        } else if (direction.x < 0) // West
        {
            carSpriteRenderer.sprite = carSprite.West;
        }
    }
}
