using System;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Controller : Agent
{
    public float speed = 10f;
    public Rigidbody rb;
    public GameObject smallGoal;
    public GameObject largeGoal;
    public Vector3 init_Pos;
    public BehaviorParameters behaviorParameters;
    public int maxStep = 1000;
    
    private int position;
    private const int k_MinPosition = 0;
    private const int k_MaxPosition = 20;
    private const int k_SmallGoalPosition = 7;
    private const int k_LargeGoalPosition = 17;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        ResetAgent();
    }

    public override void OnEpisodeBegin()
    {
        ResetAgent();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int move = actions.DiscreteActions[0]; // 0: 정지, 1: 오른쪽, 2: 왼쪽

        if (move == 1) MoveDirection(1);
        if (move == 2) MoveDirection(-1);
    }

    void MoveDirection(int direction)
    {
        position += direction;
        position = Mathf.Clamp(position, k_MinPosition, k_MaxPosition);
        transform.position = new Vector3(position - 10f, 0f, 0f);

        AddReward(-0.01f);

        if (position == k_SmallGoalPosition)
        {
            AddReward(0.1f);
            EndEpisode();
        }

        if (position == k_LargeGoalPosition)
        {
            AddReward(1f);
            EndEpisode();
        }
    }

    public void ResetAgent()
    {
        position = 10;
        transform.position = init_Pos;
        smallGoal.transform.position = new Vector3(k_SmallGoalPosition - 10f, 0f, 0f);
        largeGoal.transform.position = new Vector3(k_LargeGoalPosition - 10f, 0f, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(position);
        sensor.AddObservation(k_SmallGoalPosition);
        sensor.AddObservation(k_LargeGoalPosition);
    }
}
