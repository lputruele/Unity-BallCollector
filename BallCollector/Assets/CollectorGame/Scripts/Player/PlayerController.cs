using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using Touch = UnityEngine.Touch;
using TouchPhase = UnityEngine.TouchPhase;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PositionType state;
        private Vector2 currentMove;
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Sprite[] sprites = new Sprite[3];

        private void Start()
        {
            state = PositionType.center;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Manages input then it updates player state (position) and sprite
        private void Update()
        {
            if (Input.touchCount > 0) // Touchscreen Input
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
                    state = worldPos.x > transform.position.x ? PositionType.right : worldPos.x < transform.position.x ? PositionType.left : PositionType.center;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    state = PositionType.center;
                }
            }
            else // Keyboard Input
            {
                state = currentMove.x > 0.0f ? PositionType.right : currentMove.x < 0.0f ? PositionType.left : PositionType.center;
            }        
            ChangeSprite();
        }

        // Callback action for Keyboard input (New Unity Input System)
        public void OnMovement(InputAction.CallbackContext context)
        {
            // This returns Vector2.zero when context.canceled
            // is true, so no need to handle these separately.
            currentMove = context.ReadValue<Vector2>();
        }

        // Manage collision with falling items
        void OnTriggerEnter2D(Collider2D other)
        {
            Item item = other.gameObject.GetComponent<Item>();
            Assert.IsNotNull(item);
            if (item.position == state)
            {
                other.gameObject.SetActive(false);
                ScoreManager.AddScore(item.isBomb);
                AudioManager.instance.PlayGrabItem(item.isBomb);
            }
            
        }

        private void ChangeSprite()
        {
            int position = 0;
            if (state != PositionType.center)
            {
                position = 1;
            }
            if (state == PositionType.left)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            spriteRenderer.sprite = sprites[position];
        }
    }
}

