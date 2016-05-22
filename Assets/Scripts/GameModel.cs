using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Com.Mygame;


public class GameModel : MonoBehaviour
{
    public UFOdata disk_level;
    private DiskFactory myFactory;
    public Vector3 startPos;
    public Vector3 dirPos;
    private gSceneController scene;

    // Use this for initialization
    void Awake()
    {
        scene = gSceneController.GetInstance();
        scene.setGameModel(this);
        myFactory = DiskFactory.GetInstance();
    }

    public void setOriginData(UFOdata disklevel, Vector3 start, Vector3 dir)
    {
        disk_level = disklevel;
        startPos = start;
        dirPos = dir;
    }

    public UFOdata getDiskLevel()
    {
        return disk_level;
    }

    public void emitDisk()
    {
        for (int i = 0; i < disk_level.getEmitnum(); i++)
        {
            int id = myFactory.getDisk();
            GameObject disk = myFactory.GetDiskObject(id);
            disk.SetActive(true);
            ActionManager.GetInstance().ApplyMoveToAction(disk);
            disk.GetComponent<MoveToAction>().setId(id);
        }
    }
}
