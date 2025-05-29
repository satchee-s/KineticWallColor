using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction mouseClick;
    InputAction mousePosition;
    InputAction touchPress;

    [SerializeField] Color currColor;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        touchPress = playerControls.Input.Touch;
        touchPress.Enable();

        mouseClick = playerControls.Input.MouseLeftClick;
        mouseClick.Enable();

        mousePosition = playerControls.Input.MousePosition;
        mousePosition.Enable();
    }

    private void Update()
    {
        if (mouseClick.IsPressed() || touchPress.IsPressed())
        {
            DetectClickedObjects();
        }
    }

    private void DetectClickedObjects()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition.ReadValue<Vector2>());
        RaycastHit[] mouseHits = Physics.RaycastAll(mouseRay);

        foreach (var hit in mouseHits)
        {
            ChangeTouchedObjectColor(hit);
        }

        foreach (var touch in Touchscreen.current.touches)
        {
            if (touch.press.isPressed)
            {
                Ray _ray = Camera.main.ScreenPointToRay(touch.position.ReadValue());
                RaycastHit[] _hits = Physics.RaycastAll(_ray);

                foreach (var _hit in _hits)
                {
                    ChangeTouchedObjectColor(_hit);
                }
            }
        }
    }

    void ChangeTouchedObjectColor(RaycastHit hit)
    {
        Panel panel = hit.collider.gameObject.GetComponent<Panel>();
        if (panel != null)
        {
            panel.SetEmissionColor(currColor);
        }
    }

    private void OnDisable()
    {
        playerControls.Disable();
        mouseClick.Disable();
        mousePosition.Disable();
        touchPress.Disable();
    }
}
