using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] public GameObject[] paths;
    [SerializeField] public int countOfPaths;
    [SerializeField] float pathOfDistance;
    [SerializeField] public  float pathSpeed;
    float zPos;

    private void Start()
    {
        for (int i = 0; i < countOfPaths; i++)
        {
            if (i ==0)
            {
                spawnPath(0);
            }
            else
            {
                spawnPath(Random.Range(1,paths.Length));
            }
        }
    }


    void Update()
    {
        var pathNewPos = transform.position;
       transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(pathNewPos.z, -1000f, pathSpeed * Time.deltaTime));

    }

     void spawnPath(int index)
    {
        GameObject newPath = Instantiate(paths[index], new Vector3(transform.position.x,transform.position.y,zPos),Quaternion.identity);
        zPos += pathOfDistance;
        newPath.transform.parent = transform;

    }




}
