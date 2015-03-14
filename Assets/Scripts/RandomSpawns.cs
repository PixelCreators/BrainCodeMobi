using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawns : MonoBehaviour
{
    public static Vector2 Position(float xOffset = 0, float yOffset = 0) 
    {
        return RandomPoints.GetVector2(xOffset, Screen.width - xOffset, yOffset, Screen.height - yOffset);
    }

    public static Vector2 YPosition(float x, float yOffset = 0)
    {
        return new Vector2(x, RandomPoints.GetPoint(yOffset, Screen.height - yOffset));
    }

    public static Vector2 XPosition(float y, float xOffset = 0)
    {
        return new Vector2(RandomPoints.GetPoint(xOffset, Screen.width - xOffset), y);
    }

    public static Vector2 SquareDeletedPosition(float width, float height, float xOffset = 0, float yOffset = 0)
    {
        float x = Mathf.Abs(width)/2 , y = Mathf.Abs(height)/2;             //Obliczanie środka ekranu
        int screenPart = Random.Range(1, 5);                                //Wybieranie części ekranu w której ma zostać
                                                                            //wylosowany punkt
        /* W zależności od miejsca wylosowanego punktu
         * gra oblicza pozycję punktu losując losowy punkt w
         * jednej z czterech części ekranu.
         */

        switch (screenPart)
        {
            case 1:
                return RandomPoints.GetVector2(xOffset, Screen.width - xOffset, yOffset, Screen.height/2 - height/2);
             case 2:
                return RandomPoints.GetVector2(xOffset, Screen.width - xOffset, Screen.height / 2 + height / 2, Screen.height - yOffset);
             case 3:
                return RandomPoints.GetVector2(xOffset, Screen.width/2 - width/2, yOffset, Screen.height - yOffset);
            case 4:
                return RandomPoints.GetVector2(Screen.width / 2 + width / 2, Screen.width - xOffset, yOffset, Screen.height - yOffset);
        }
        throw new Exception("Coś się posypało");        //Ten wyjątek tak wiele mówi... 
    }

    public static Vector3 Vector2ToVector3WorldPoint(Vector2 point)
    {
       //Przerzucanie Vectora2 na Vector3
        Vector3 tmp = Camera.main.ScreenToWorldPoint(point);
        return new Vector3(tmp.x, tmp.y, 0);
    }


    //Todo:: Dodać obsługę 3D
}

public class RandomPoints
{
    //Nic specjalnego, losujemy po prostu wektory. 
    public static float GetPoint(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static Vector2 GetVector2(float minWidth, float maxWidth, float minHeight, float maxHeight)
    {
        return new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
    }

    public static Vector3 GetVector3(float minWidth, float maxWidth, float minHeight, float maxHeight, float minDepth, float maxDepth)
    {
        return new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), Random.Range(minDepth, maxDepth));
    }
}
