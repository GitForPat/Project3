using UnityEngine;

public class winCase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        collision.gameObject.GetComponent<playerMain>().MyUIController.showWinCase();
    }
}
