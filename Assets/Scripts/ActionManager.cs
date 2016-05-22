using UnityEngine;
using System.Collections;
using Com.Mygame;

namespace Com.Mygame
{
    public class ActionManager : System.Object
    {
        private static ActionManager _instance;

        public static ActionManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ActionManager();
            }
            return _instance;
        }
        public U3dAciton ApplyMoveToAction(GameObject obj)
        {
            MoveToAction ac = obj.AddComponent<MoveToAction>();
            return ac;
        }

        public void Free(U3dAciton ac)
        {
            ac.Free();
        }
    }
}
