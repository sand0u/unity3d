using UnityEngine;
using System.Collections;
using Com.Mygame;
using UnityEngine.UI;



public class UserInterface : MonoBehaviour
{

    public Text TimeText;
    public Text RoundText;
    public Text ScoreText;
    public GameObject bullet;
    private IUserInterface uInt;
    private IGameStatus query;
    private IJudgeEvent judge;
    float thistime = 0;
    private bool isSpacce = false;
    private DiskFactory myFactory;
    // Use this for initialization
    void Start()
    {
        uInt = gSceneController.GetInstance() as IUserInterface;
        query = gSceneController.GetInstance() as IGameStatus;
        judge = gSceneController.GetInstance() as IJudgeEvent;
        myFactory = DiskFactory.GetInstance();
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (Input.GetKeyDown("space"))
        {
            isSpacce = true;
        }
        if (isSpacce)
        {
            if (query.getTrial() == false)
            {
                //倒计时
                thistime += Time.deltaTime;
                if (thistime < 1f)
                {
                    TimeText.text = "3";
                }
                else if (thistime > 1f && thistime < 2f)
                {
                    TimeText.text = "2";
                }
                else if (thistime > 2f && thistime < 3f)
                {
                    TimeText.text = "1";
                }
                else if (thistime > 3f)
                {
                    TimeText.text = "";
                    judge.RoundStart();
                }
            }
            else
            {
                uInt.emitDisk();
                judge.RoundEnd();
                isSpacce = false;
                thistime = 0;
            }
        }
        else {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;//初速度
                bullet.transform.position = Camera.main.transform.position;
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 500f, ForceMode.Impulse);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Disk")
                {
                    myFactory.Free(hit.collider.gameObject.GetComponent<MoveToAction>().getId());
                    judge.addScoreEvent();
                }
            }
        }
        RoundText.text = "Round: " + query.getRound();
        ScoreText.text = "Score: " + query.getScore();
    }
}
