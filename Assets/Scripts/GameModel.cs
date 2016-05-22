using UnityEngine;
using System.Collections;

public class GameModel : MonoBehaviour {

    [System.Serializable]
    public class UFOdata
    {
        public int diskScale;
        public Color diskColor;
        public Vector3 startPos;
        public Vector3 dirPos;
        public float emitspeed;
        public int emitNum;
    }

    void Awake()
    {
        UFOdata ufo_data = new UFOdata();

    }
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
