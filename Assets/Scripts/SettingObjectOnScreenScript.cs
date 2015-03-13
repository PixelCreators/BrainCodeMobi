using UnityEngine;
using System.Collections;

public class SettingObjectOnScreenScript : MonoBehaviour
{
    public Vector2 offsetFromCameraBounds;
    public bool addScreenWidth = false;
    public bool addScreenHeight = false;
    public bool preserveCurrentXPosition = false;
    public bool preserveCurrentYPosition = false;

    void Start()
    {
        setPositionAwayFromCam();
    }

    void setPositionAwayFromCam()
    {
        if (addScreenWidth)
            addWidthToBounds();

        if (addScreenHeight)
            addHeightToBounds();

        setNewPositionFromScreenToWorldPoint();
    }

    void addWidthToBounds()
    {
        offsetFromCameraBounds.x += Screen.width;
    }

    void addHeightToBounds()
    {
        offsetFromCameraBounds.y += Screen.height;
    }

    void setNewPositionFromScreenToWorldPoint()
    {
        Vector3 newPosition = offsetFromCameraBounds;
        newPosition.z = 0;                             

        Vector2 calculatedPosition = Camera.main.ScreenToWorldPoint(new Vector3(newPosition.x, newPosition.y, 0));

        if (preserveCurrentXPosition)
            calculatedPosition.x = transform.position.x;

        if (preserveCurrentYPosition)
            calculatedPosition.y = transform.position.y;

        transform.position = new Vector3(calculatedPosition.x, calculatedPosition.y, 0);

    }

}
