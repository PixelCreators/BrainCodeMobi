﻿using UnityEngine;
using System.Collections;

public class SetRandomPosition : MonoBehaviour
{
    private Transform transform;

    public enum RandomType
    {
        WholeScene,
        X_Axis,
        Y_Axis,
        RectangleLess
    }

    public RandomType randomType;

    public Vector2 DefaultPosition;
    public Vector2 Offsets;
    public Vector2 RectangleSize;

    public bool SetRectangleSizeOverScreen;

    void Awake()
    {
        transform = gameObject.transform;
    }

    void Start()
    {
        switch (randomType)
        {
            case RandomType.WholeScene:
                transform.position = RandomSpawns.Vector2ToVector3WorldPoint(RandomSpawns.Position(Offsets.x, Offsets.y));
                break;
            case RandomType.X_Axis:
                transform.position = RandomSpawns.Vector2ToVector3WorldPoint(RandomSpawns.XPosition(DefaultPosition.y + Offsets.y, Offsets.x));
                break;
            case RandomType.Y_Axis:
                transform.position = RandomSpawns.Vector2ToVector3WorldPoint(RandomSpawns.YPosition(DefaultPosition.x + Offsets.x, Offsets.y));
                break;
            case RandomType.RectangleLess:
                if (SetRectangleSizeOverScreen)
                {
                    transform.position =
                        RandomSpawns.Vector2ToVector3WorldPoint(RandomSpawns.SquareDeletedPosition(Screen.width, Screen.height, Offsets.x,
                            Offsets.y));
                }
                else
                {
                    transform.position =
                        RandomSpawns.Vector2ToVector3WorldPoint(RandomSpawns.SquareDeletedPosition( RectangleSize.x,
                                                                                                    RectangleSize.y, Offsets.x,
                                                                                                                     Offsets.y));
                }
                break;
        }
    }

    void OnDrawGizmos()
    {
    }
}
