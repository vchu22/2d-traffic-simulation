using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Vector3 _dragOrigin;
    private Vector3 _mouseDelta;
    private Camera _mainCamera;
    private bool _isDragging;

    private void Awake()
    {
        // Initialize camera and input actions
        _mainCamera = Camera.main;
    }
    public void OnMouseDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _dragOrigin = this.GetMousePosition;
        }
        _isDragging = ctx.started || ctx.performed;
    }
    private void LateUpdate()
    {
        if (_isDragging)
        {
            _mouseDelta = GetMousePosition - transform.position;
            transform.position = (_dragOrigin - _mouseDelta);
        }
    }

    private Vector3 GetMousePosition => _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}
