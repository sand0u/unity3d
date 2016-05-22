using UnityEngine;
using System.Collections;
using Com.Mygame;

public class Judge : MonoBehaviour
{
    private gSceneController gscene;

    void Awake()
    {
        gscene = gSceneController.GetInstance();
        gscene.setJudge(this);
    }


    public void getData(int Round)
    {
        switch (Round)
        {
            case 1:

                //color = Color.yellow;
                //emitPos = new Vector3(-2.5f, 0.2f, -5f);
                //emitDir = new Vector3(24.5f, 40.0f, 67f);
                gscene.getGameModel().setOriginData();
                break;

            case 2:
                color = Color.red;
                emitPos = new Vector3(2.5f, 0.2f, -5f);
                emitDir = new Vector3(-24.5f, 35.0f, 67f);
                gscene.getGameModel().setOriginData(1, color, emitPos, emitDir, 5f, 2);
                break;
            case 3:

        }
    }
}
