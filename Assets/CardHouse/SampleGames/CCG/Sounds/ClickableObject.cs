using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [Header("Actions to perform when clicked")]
    public UnityEvent onClick;

    void OnMouseDown()
    {
        onClick?.Invoke();
        Debug.Log("click");
    }
}