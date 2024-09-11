using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TestScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField][Range(1, 100)] int _health;
    [Space]
    [SerializeField][Range(1, 10)] int _speed;

    [Tooltip("Это поле пока не используется")][SerializeField] int _damage;

    [HideInInspector] public string AnimationType;

    [ContextMenu("Напечатать привет")]
    void PrintHello()
    {
        Debug.Log("Hello");
    }
}
