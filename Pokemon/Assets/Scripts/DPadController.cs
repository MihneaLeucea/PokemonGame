using UnityEngine;

public class DPadController : MonoBehaviour
{
    public bool upPressed;
    public bool downPressed;
    public bool leftPressed;
    public bool rightPressed;

    public void OnUpPressed(bool pressed) => upPressed = pressed;
    public void OnDownPressed(bool pressed) => downPressed = pressed;
    public void OnLeftPressed(bool pressed) => leftPressed = pressed;
    public void OnRightPressed(bool pressed) => rightPressed = pressed;
}
