using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public bool isHoldDown;

    public void isHoldingDown(bool i)
    {
        isHoldDown = i;
    }
}