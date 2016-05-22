using UnityEngine;
using System.Collections;

[System.Serializable]
public class UFOdata
{
    public string title;
    public int diskScale;
    public int turn;
    public Color diskColor;
    public float emitspeed;
    public int emitNum;

    public string getTitle()
    {
        return title;
    }
    public int getDiskScale()
    {
        return diskScale;
    }
    public int getTurn()
    {
        return turn;
    }
    public Color getDiskColor()
    {
        return diskColor;
    }
    public float getEmitspeed()
    {
        return emitspeed;
    }
    public int getEmitnum()
    {
        return emitNum;
    }

}
