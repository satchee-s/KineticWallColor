using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction touchPress;
    InputAction mouseClick;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        touchPress = playerControls.Input.Touch;
        touchPress.Enable();

        mouseClick = playerControls.Input.MouseLeftClick;
        mouseClick.Enable();
    }

    private void Update()
    {
        if (touchPress.IsPressed())
        {
            DetectTouchedObjects();
        }
    }

    private void DetectTouchedObjects()
    {
        if (Touchscreen.current != null)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.isPressed)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position.ReadValue());
                    RaycastHit[] hits = Physics.RaycastAll(ray);

                    foreach (var hit in hits)
                    {
                        ChangeTouchedObjectColor(hit);
                    }
                }
            }
        }
    }

    void ChangeTouchedObjectColor(RaycastHit hit)
    {
        hit.collider.gameObject.GetComponent<Panel>().SetEmissionColor(Color.white);
    }

    private void OnDisable()
    {
        playerControls.Disable();
        touchPress.Disable();
        mouseClick.Disable();
    }
}
