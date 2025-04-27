using CardHouse;
using Unity.VisualScripting;
using UnityEngine;

public class dick : MonoBehaviour
{
    public CardTransferOperator operator1;
    public CardTransferOperator operator2;
    void Start()
    {
        Debug.Log("Scene started! Do something here...");
        // Example: call your function or start an event
        operator1.Activate();
        operator2.Activate();
        MyCustomAction();
    }

    void MyCustomAction()
    {
        // Your custom logic here
        Debug.Log("Custom action triggered!");
    }
}
