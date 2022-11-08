using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Private Properties
    private int roadLength = 40;
    private Ball ball;
    private Hashtable corridorsPos = new Hashtable();
    #endregion

    #region Public Properties
    public float[] levelHardness;
    public Ball ballPrefab;
    public Corridor corridorPrefab;
    public CameraFollow cameraFollow;


    public int XBallPosition => (int)Mathf.Floor(Ball.transform.position.x);

    public Ball Ball { get => ball;  }

    private List<Corridor> corridorsList = new List<Corridor>();


    public int length = 1;
    public bool started = false;

    #endregion

    public void Clear()
    {
        if (corridorsList.Count > 0)
        {
            for (int i = 0; i < corridorsList.Count; i++)
            {
                Destroy(corridorsList[i].gameObject);
            }
            corridorsList.Clear();
            corridorsPos.Clear();
            Destroy(ball.gameObject);
        }
    }

    public void SpawnRoad(int length, bool init = false)
    {
        length *= roadLength;
        for (int x = -length; x < length; x += roadLength)
        {
            Vector3 pos = new Vector3(x + XBallPosition, 0, 0);

            if (!corridorsPos.ContainsKey(pos))
            {
                Corridor newCorridor;
                if (init)
                {
                    newCorridor = Instantiate(corridorPrefab, pos, Quaternion.identity, transform);
                    corridorsList.Add(newCorridor);
                }
                else
                {
                    newCorridor = corridorsList[0];
                    newCorridor.transform.position = pos;
                    corridorsList.MoveFirstToEnd();
                }
                corridorsPos.Add(pos, newCorridor.gameObject);
            }
        }
    }

    public void StartGame(int levelHardnessIndex)
    {
      
        ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        ball.HorizontalSpeed = levelHardness[levelHardnessIndex];
        cameraFollow.player = Ball.transform;
        SpawnRoad(length, true);
        started = true;
    }

    private void Update()
    {
        if (started)
        {
            if (Mathf.Abs(XBallPosition) % roadLength == 0)
            {
                SpawnRoad(length);
            }
        }
    }

}

public static class ListExtension
{
    public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
    {
        T item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);
    }

    public static void MoveFirstToEnd<T>(this List<T> list)
    {
        T item = list[0];
        list.RemoveAt(0);
        list.Insert(list.Count - 1, item);
    }
}


