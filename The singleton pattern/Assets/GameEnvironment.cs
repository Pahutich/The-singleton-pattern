using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class GameEnvironment
{
  private static GameEnvironment instance;
  private List<GameObject> obstacles = new List<GameObject>();

  public List<GameObject> Obstacles { get { return obstacles; } }
  public List<GameObject> goalLocations = new List<GameObject>();
  public static GameEnvironment Singleton
  {
    get
    {
      if (instance == null)
      {
        instance = new GameEnvironment();
        instance.goalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));
      }
      return instance;
    }
  }

  public GameObject GetRandomGoal()
  {
    int index = Random.Range(0, goalLocations.Count);
    return goalLocations[index];
  }

  public void AddObstacles(GameObject go)
  {
    obstacles.Add(go);
  }

  public void RemoveObstacle(GameObject go)
  {
    int index = obstacles.IndexOf(go);
    obstacles.RemoveAt(index);
    GameObject.Destroy(go);
  }
}
