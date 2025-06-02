using UnityEngine;

public static class Utils
{
    public static int GetIntFromLayer(LayerMask layer)
    {
        int pos = 0;
        int num = layer.value;

        if (num == 0 || num == -1) return num;

        while (num % 2 != 1)
        {
            pos++;
            num /= 2;
        }

        return pos;
    }
}