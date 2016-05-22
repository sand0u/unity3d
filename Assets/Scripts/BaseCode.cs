using UnityEngine;
using System.Collections;
using Com.Mygame;

namespace Com.Mygame
{
    //UserInterface

    public interface IUserInterface
    {
        void emitDisk();
    }
    public interface IGameStatus
    {
        int getRound();
        int getScore();
        bool getTrial();
    }
    public interface IJudgeEvent
    {
        void addScoreEvent();
        void RoundStart();
        void RoundEnd();
    }

    // ActionManager

    public class U3dActionException : System.Exception { }

    public class U3dAciton : MonoBehaviour
    {
        public void Free()
        {
            Destroy(this);
        }
    }

    public class U3dActionAuto : U3dAciton { }

    public class U3dActionMan : U3dAciton { }


    public class MoveToAction : U3dActionAuto
    {
        private GameModel gm;
        private int id;
        // Use this for initialization

        public void setId(int i)
        {
            id = i;
        }
        public int getId()
        {
            return id;
        }
        void Start()
        {
            gm = gSceneController.GetInstance().getGameModel();
            transform.localScale *= gm.getScale();
            transform.GetComponent<Renderer>().material.color = gm.getColor();
            transform.position = gm.getStartpos();
            this.gameObject.SetActive(true);
            this.gameObject.GetComponent<Rigidbody>().AddForce(gm.getDirpos() * gm.getSpeed(), ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < 0)
            {
                DiskFactory.GetInstance().Free(id);
                Destroy(this);
            }
        }
    }
}

public class BaseCode : MonoBehaviour
{

    public string myName;

    // Use this for initialization
    void Start()
    {
        gSceneController my = gSceneController.GetInstance();
        my.setBeseCode(this);
        myName = "UFO";

    }
}