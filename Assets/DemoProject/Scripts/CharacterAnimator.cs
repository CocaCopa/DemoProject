using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

    private const string IS_GROUNDED = "IsGrounded";
    private const string IS_RUNNING = "IsRunning";

    private PlayerController controller;
    private Animator animator;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        bool isGrounded = controller.IsGrounded;
        bool isRunning = controller.IsRunning;

        animator.SetBool(IS_GROUNDED, isGrounded);
        animator.SetBool(IS_RUNNING, isRunning);
    }
}
