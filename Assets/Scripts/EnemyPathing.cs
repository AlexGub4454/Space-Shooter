using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> WayPoints;
    [SerializeField]
    float movespeed;
    [SerializeField]
    int WayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        WayPoints = waveConfig.GetWayPoints();
        transform.position = WayPoints[WayPointIndex].transform.position;
    }
    public void SetEnemyParthing(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {

        if (WayPointIndex <= WayPoints.Count-1)
        {
            var speed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            var TargetPoint = WayPoints[WayPointIndex];
            transform.position = Vector2.MoveTowards(transform.position, TargetPoint.transform.position, speed);
            if (transform.position==TargetPoint.transform.position)
            {
                WayPointIndex++;
            }
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
