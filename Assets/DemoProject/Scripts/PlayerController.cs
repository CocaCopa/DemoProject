using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [Space(10)]
    [SerializeField] private float jumpPower;

    private Rigidbody2D characterRb;
    private SpriteRenderer characterRenderer;
    private float horizontalInput;
    private bool isGrounded;

    // This property can be accessed by any script requiring knowledge of whether the character is grounded. In this project, the only script
    // utilizing thisinformation is the CharacterAnimator.cs, which helps in playing the appropriate animation based on the character's state.
    public bool IsGrounded { get { return isGrounded; } }
    // Same as the 'IsGrounded' property. Note that both of the properties are marked as 'Read-Only' (get) and their value cannot change outside of this class.
    // If we want to allow changes to a property from an external script we would need to mark the propery as get; set;
    public bool IsRunning { get { return horizontalInput != 0f; } }

    private void Awake() {
        // We know that the Rigidbody2D component is attached to the same game object as this script. Thus we can use the 'GetComponent' function to reference it
        // and access its properties. Note that if the component was attached to another game object we would need a reference to that game object before being able
        // to reference the component.
        // Some exceptions would be:
        // 1. Said game object was a child object of the object that has this script attached.
        // 2. Said game object has a script that is instantiated only once in our scene and can be referenced using 'FindObjectOfType<MyScript>();'
        characterRb = GetComponent<Rigidbody2D>();
        // We know that the SpriteRenderer component is attached to a child object of the game object that this script is attached to.
        // (Parent object: Player --- Child object: Visuals)
        // In cases where we know that a component is attached to a child, 'GetComponentInChildren' is incredibly useful as it provides direct access to the component we need.
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() {
        // The 'GetAxisRaw' function returns -1 when the player presses the 'Left Arrow' or 'A' key and 1 when they press the 'Right Arrow' or 'D' key.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        RestartLevel();
        FlipCharacter();
        MoveCharacter();
        CharacterJump();
        RespawnPlayer();
    }

    // Flip the character sprite to face the correct direction based on the direction they are moving toward.
    private void FlipCharacter() {
        // If our player wants to head in the LEFT direction...
        if (horizontalInput < 0) {
            // ...We mirror the character's sprite.
            characterRenderer.flipX = true;
        }
        // Else if they want to head in the RIGHT direction...
        else if (horizontalInput > 0) {
            // ...We revert the sprite back to its normal state.
            characterRenderer.flipX = false;
        }
    }

    // Move the character according to the horizontal input provided by the player.
    private void MoveCharacter() {
        // The current speed of the character in the X axis.
        float currentHorizontalVelocity = characterRb.velocity.x;
        // The desired speed for our character to achieve upon receiving player input.
        float targetHorizontalVelocity = horizontalInput * moveSpeed;
        // Calculate the interpolation time in order to be used in order to interpolate our character's speed.
        float interpolationTime = acceleration * Time.deltaTime;
        // Linearly interpolate the character's speed from its CURRENT speed to the TARGET speed, taking into account the calculated interpolation time.
        float newHorizontalVelocity = Mathf.Lerp(currentHorizontalVelocity, targetHorizontalVelocity, interpolationTime);

        // Now that we've calculated the desired speed, we can set it for our character.
        // Store the current velocity of our character to a new Vector3 value.
        Vector3 characterVelocity = characterRb.velocity;
        // Set the X value of the vector to the speed value we calculated above.
        characterVelocity.x = newHorizontalVelocity;
        // Assign the new vector value to our character's Rigidbody component.
        characterRb.velocity = characterVelocity;
    }

    // Have the character jump when the player presses the Space Bar key and only if the character is on the ground.
    private void CharacterJump() {
        // Our character will be able to jump not only when the player presses the assigned key but also when the character is on the ground."
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            // Store the current velocity of our character into a new Vector3 value.
            Vector3 characterVelocity = characterRb.velocity;
            // Momenterally (just for one frame) we set the speed of our character in the Y axis to the desired jump power value.
            // This will cause our character to launch into the air. Since the character has a Rigidbody component attached, gravity will
            // gradually pull the character back towards the ground.
            characterVelocity.y = jumpPower;
            // Assign the new vector value to our character's Rigidbody component.
            characterRb.velocity = characterVelocity;
        }
    }

    // Reset the player's position if they fall under the map.
    private void RespawnPlayer() {
        // We check whether the character's position in the world along the Y-axis is below -15. If this condition is met, we reset their position to (0, 0, 0) and also reset their velocity.
        if (transform.position.y < -15f) {
            characterRb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
        }
    }

    // Restarts the level by reloading the scene if the Escape key is pressed.
    private void RestartLevel() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // For now, don't mind this line of code right here. It just replays the scene as if we stopped the game and started it again.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Note that for both of the callbacks below to function properly, the object to which this script is attached must have a Collider2D component attached and must not be set as a trigger.
    // This requirement also applies to the other object involved in the collision.

    // Called when the object with this script attached makes contact with another object that has a collider component attached.
    private void OnCollisionEnter2D(Collision2D collision) {
        isGrounded = true;
    }

    // Called when the object with this script attached loses contact with another object that has a collider component attached.
    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    }
}
