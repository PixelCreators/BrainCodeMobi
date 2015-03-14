using UnityEngine;
using System.Collections;

public class ScaleCollider : MonoBehaviour 
{
    private BoxCollider2D col;

	void Start () 
    {
        col = GetComponent<BoxCollider2D>();
        Vector2 endScreenPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 startScreenPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        col.size = new Vector2(col.size.x, Mathf.Abs(endScreenPoint.y - startScreenPoint.y));
	}
	

}
