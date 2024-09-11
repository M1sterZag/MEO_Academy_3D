using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float duration;
    private float currentTime;
    private Vector3 startPosition;
    

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float progress = currentTime / duration;
        gameObject.transform.position = new Vector3(transform.position.x, startPosition.y + animationCurve.Evaluate(progress), transform.position.z);
        currentTime += Time.deltaTime;
        if (currentTime > duration)
        {
            currentTime = 0;
        }
    }
}
