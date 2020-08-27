using UnityEngine;
using UnityEditor;

public static class Utils
{
    public static UnityEngine.Color GetColor(int colorValue)
    {
        UnityEngine.Color color = UnityEngine.Color.white;
        if (colorValue == Color.GREEN.Value)
        {
            color = new Color32(0, 255, 0, 255);
        }
        else if (colorValue == Color.RED.Value)
        {
            color = new Color32(255, 0, 0, 255);
        }
        else if (colorValue == Color.BLACK.Value)
        {
            color = new Color32(0, 0, 0, 255);
        }
        return color;
    }
}