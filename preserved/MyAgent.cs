using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MyAgent : Agent
{
    public Transform target;
    private Rigidbody rb;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody missing on the agent!");
        }
    }

    // 에피소드가 시작될 때마다 에이전트와 타겟을 리셋
    public override void OnEpisodeBegin()
    {
        // Agent 위치와 속도 초기화
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector3.zero;

        // 타겟 위치를 랜덤으로 배치, 예)
        target.localPosition = new Vector3(
            Random.Range(-4f, 4f), 
            0f,
            Random.Range(-4f, 4f)
        );
    }

    // 관측
    public override void CollectObservations(VectorSensor sensor)
    {
        // 에이전트의 위치 (3D)
        sensor.AddObservation(transform.localPosition);

        // 목표와의 거리 (스칼라)
        sensor.AddObservation(Vector3.Distance(transform.localPosition, target.localPosition));

        // 속도 (3D)
        sensor.AddObservation(rb.velocity);
    }

    // 액션을 받아 실제 행동
    public override void OnActionReceived(ActionBuffers actions)
    {
        // ContinuousActions[0], ContinuousActions[1] : 이동 입력
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        // 가벼운 힘을 가해본다
        rb.AddForce(new Vector3(moveX, 0f, moveZ) * 5f);

        // 간단한 보상/종료 조건
        float distanceToTarget = Vector3.Distance(transform.localPosition, target.localPosition);
        if (distanceToTarget < 1.0f)
        {
            // 타겟에 근접 시 보상 부여 후 에피소드 종료
            SetReward(1f);
            EndEpisode();
        }

        // 혹은 너무 멀리 떨어지거나 바닥 아래로 떨어지면 에피소드 종료
        if (transform.localPosition.y < -1f || distanceToTarget > 20f)
        {
            EndEpisode();
        }
    }
}
