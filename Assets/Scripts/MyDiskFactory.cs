using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Com.Mygame;

namespace Com.Mygame
{
    public class DiskFactory : System.Object
    {
        private static DiskFactory _instance;
        private static List<GameObject> disk_List;
        public GameObject disk_template;

        public static DiskFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DiskFactory();
                disk_List = new List<GameObject>();
            }
            return _instance;
        }

        public int getDisk()
        {
            for (int i = 0; i < disk_List.Count; i++)
            {
                if (disk_List[i].activeInHierarchy == false)
                    return i;
            }
            disk_List.Add(GameObject.Instantiate(disk_template) as GameObject);
            return disk_List.Count - 1;
        }

        public GameObject GetDiskObject(int id)
        {
            if (id >= 0 && id < disk_List.Count)
            {
                return disk_List[id];
            }
            return null;
        }

        public void Free(int id)
        {
            if (id >= 0 && id < disk_List.Count)
            {
                //回收时注意重置飞碟对象属性
                disk_List[id].GetComponent<Rigidbody>().velocity = Vector3.zero;
                // 重置飞碟大小  
                disk_List[id].transform.localScale = disk_template.transform.localScale;

                disk_List[id].SetActive(false);
            }
        }
    }
}
public class myDiskFactory : MonoBehaviour
{
    public GameObject disk;

    void Awake()
    {
        // 初始化预设对象  
        DiskFactory.GetInstance().disk_template = disk;
    }
}