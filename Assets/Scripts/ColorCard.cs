using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCard
{

    public enum Color
    {
        RED, GREEN, BLUE, YELLOW, NONE
    }

    public enum Type
    {
        STANDARD, DRAW2, SKIP, REVERSE, WILD, WILD4, WILDRANDOM
    }

    private Color color;
    private Type type;
    private int value; // 0-9

    public ColorCard(Type _t, Color _c, int _val)
    {
        color = _c;
        value = _val;
        type = _t;
    }

    public Type GetType()
    {
        return type;
    }

    public Color GetColor()
    {
        return color;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetColor(ColorCard.Color c)
    {
        color = c;
    }
}

