using UnityEngine;
using UnityEngine.UI;

public class CoinCounterUI : MonoBehaviour {

    private Text coinCounterText;
    private int coinsCollected;

    private void Awake() {
        coinCounterText = GetComponent<Text>();
        coinCounterText.text = "Coins Collected: 0";
    }

    public void CoinCollected() {
        coinsCollected++;
        coinCounterText.text = "Coins Collected: " + coinsCollected;
    }
}
