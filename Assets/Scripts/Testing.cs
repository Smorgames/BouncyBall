using UnityEngine;

public class Testing : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            print(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
    }
}
