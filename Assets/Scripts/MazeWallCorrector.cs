using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeWallCorrector : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> walls;
    void Start()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("wallN"))
        {
            walls.Add(wall);
        }
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("wallS"))
        {
            walls.Add(wall);
        }
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("wallE"))
        {
            walls.Add(wall);
        }
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("wallW"))
        {
            walls.Add(wall);
        }

        foreach (GameObject i in walls)
        {
            foreach (GameObject j in walls)
            {
                if (i != j)
                {
                    if (i.transform.position.z - j.transform.position.z < 0.005)
                    {
                        //Debug.Log(i.ToString() + j.ToString());
                        //Destroy(j);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
