using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry
{
    public static float CalulateParabolaWithTurningPoint(Vector3 parabola, float x)
    {
        float tmp = x - parabola.y;
        tmp *= tmp;
        return parabola.x * tmp + parabola.z;
    }

    public static Vector3 GetParabola(Vector3 pos0, Vector3 posF, float height)
    {
        float xs = pos0.x + posF.x;
        xs /= 2;

        float ys = pos0.y + height;

        float a = -ys / ((pos0.x - xs) * (pos0.x - xs));

        return new Vector3(a, xs, ys);
    }
}
