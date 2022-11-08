using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float xDistance = 10;
    public float ySpread = 3;

    public Transform obstaclePrefab;
    public LevelManager levelManager;


    private List<Transform> obstaclesBuffer = new List<Transform>();
    float lastXPos;

    public void Clear()
    {
        lastXPos = Mathf.NegativeInfinity;
        if (obstaclesBuffer.Count > 0)
        {
            for (int i = 0; i < obstaclesBuffer.Count; i++)
            {
                Destroy(obstaclesBuffer[i].gameObject);
            }
            obstaclesBuffer.Clear();
        }
    }

    void Start()
    {
        lastXPos = Mathf.NegativeInfinity;
    }

    void Update()
    {
        if (levelManager.started)
            if (levelManager.XBallPosition - lastXPos >= xDistance)
            {
                Transform current;
                Vector2 pos = new Vector3(levelManager.XBallPosition + xDistance, Random.Range(-ySpread, ySpread), 0);

                if (obstaclesBuffer.Count <= 5)
                {
                    current = Instantiate(obstaclePrefab, pos, Quaternion.identity);
                    obstaclesBuffer.Add(current);
                }
                else
                {
                    current = obstaclesBuffer[0];
                    current.transform.position = pos;
                    obstaclesBuffer.MoveFirstToEnd();
                }

                lastXPos = levelManager.XBallPosition;
            }
    }
}
