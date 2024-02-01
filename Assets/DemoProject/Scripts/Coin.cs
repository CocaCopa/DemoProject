using UnityEngine;

public class Coin : MonoBehaviour {

    private const string PLAYER_TAG = "Player";
    private const string COIN_ANIMATION_STATE_NAME = "Coin";

    private CoinCounterUI coinCounterUI;
    private Animator animator;

    private void Awake() {
        coinCounterUI = FindObjectOfType<CoinCounterUI>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start() {
        float randomTime = Random.Range(0f, 1f);
        animator.Play(COIN_ANIMATION_STATE_NAME, 0, randomTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(PLAYER_TAG)) {
            coinCounterUI.CoinCollected();
            Destroy(gameObject);
        }
    }
}
