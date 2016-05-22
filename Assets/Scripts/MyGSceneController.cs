using UnityEngine;
using System.Collections;
using Com.Mygame;
namespace Com.Mygame
{
    public class gSceneController : System.Object, IGameStatus, IUserInterface, IJudgeEvent
    {

        private static gSceneController _instance;
        private BaseCode _base_code;
        private GameModel _ufo_game_model;
        private Judge _game_judge;
        private static int Round;
        private static bool Trial;
        private static int Score;


        public static gSceneController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new gSceneController();
                Round = 1;
                Score = 0;
            }
            return _instance;
        }

        public BaseCode getBaseCode()
        {
            return _base_code;
        }
        internal void setBeseCode(BaseCode bc)
        {
            if (_base_code == null)
            {
                _base_code = bc;
            }
        }
        public GameModel getGameModel()
        {
            return _ufo_game_model;
        }
        internal void setGameModel(GameModel ufo)
        {
            if (_ufo_game_model == null)
            {
                _ufo_game_model = ufo;
            }
        }

        public Judge getJudge()
        {
            return _game_judge;
        }
        internal void setJudge(Judge jd)
        {
            if (_game_judge == null)
            {
                _game_judge = jd;
            }
        }

        public void emitDisk()
        {
            _ufo_game_model.emitDisk();
        }
        public int getRound()
        {
            return Round;
        }
        public int getScore()
        {
            return Score;
        }
        public bool getTrial()
        {
            return Trial;
        }
        public void addScoreEvent()
        {
            Score += 5;
            if (Score >= 40)
            {
                Score = 0;
                if (Round > 1)
                {
                    Round = 0;
                }
                _game_judge.getData(++Round);
            }
        }
        public void RoundStart()
        {
            Trial = true;
            _game_judge.getData(Round);
        }
        public void RoundEnd()
        {
            Trial = false;
        }
    }
}

public class MyGSceneController : MonoBehaviour
{

    void Awake()
    {
        // 初始化预设对象  
        gSceneController.GetInstance();
    }
}