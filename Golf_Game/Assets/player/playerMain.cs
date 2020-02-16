using UnityEngine;
using UnityEngine.InputSystem;

public class playerMain : MonoBehaviour
{
    private InputControllerPlayer controls;

    private float speed;
    private int strokes;
    private Vector2 move;

    private bool statusAffectEnlarge;
    private bool statusAffectShrink;
    private bool statusAffectSpeedUp;
    private bool statusAffectSpeedSlow;
    private bool statusAffectCanClimb;
    private bool statusAffectNoClimb;

    private uiController myUIController;

    public bool StatusAffectEnlarge { get => statusAffectEnlarge; set => statusAffectEnlarge = value; }
    public bool StatusAffectShrink { get => statusAffectShrink; set => statusAffectShrink = value; }
    public bool StatusAffectSpeedUp { get => statusAffectSpeedUp; set => statusAffectSpeedUp = value; }
    public bool StatusAffectSpeedSlow { get => statusAffectSpeedSlow; set => statusAffectSpeedSlow = value; }
    public bool StatusAffectCanClimb { get => statusAffectCanClimb; set => statusAffectCanClimb = value; }
    public bool StatusAffectNoClimb { get => statusAffectNoClimb; set => statusAffectNoClimb = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Strokes { get => strokes; set => strokes = value; }
    public uiController MyUIController { get => myUIController; set => myUIController = value; }

    private void Awake() {
        controls = new InputControllerPlayer();

        speed = 15.0f;
        strokes = 15;

        statusAffectEnlarge = false;
        statusAffectShrink = false;
        statusAffectSpeedUp = false;
        statusAffectSpeedSlow = false;
        statusAffectCanClimb = false;
        statusAffectNoClimb = false;

        myUIController = GameObject.FindGameObjectsWithTag("UI")[0].GetComponent<uiController>();

        controls.playerControls.move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.playerControls.move.canceled += ctx => move = Vector2.zero;
    }

    private void Update() {
        if(strokes <= 0) {
            myUIController.showFailCase();
        }
    }

    private void FixedUpdate() {
        Vector2 m = move * speed * Time.deltaTime;
        this.gameObject.transform.Translate(m, Space.World);
    }

    public void OnEnable() {
        controls.playerControls.Enable();
    }

    public void OnDisable() {
        controls.playerControls.Disable();
    }
}
