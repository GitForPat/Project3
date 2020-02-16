using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    private playerMain myPlayer;
    [SerializeField]
    TextMeshProUGUI strokeText;
    [SerializeField]
    TextMeshProUGUI levelName;
    [SerializeField]
    GameObject loseCase;
    [SerializeField]
    GameObject winCase;

    public TextMeshProUGUI StrokeText { get => strokeText; set => strokeText = value; }
    public TextMeshProUGUI LevelName { get => levelName; set => levelName = value; }

    private void Awake() {
        myPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<playerMain>();
    }

    private void LateUpdate() {
        strokeText.text = "Strokes Left: " + myPlayer.Strokes; //will fix later
    }

    public void showFailCase() {
        loseCase.SetActive(true);
    }

    public void showWinCase() {
        winCase.SetActive(true);
    }

    public void reloadLevel() {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame() {
        Application.Quit();
    }
}
