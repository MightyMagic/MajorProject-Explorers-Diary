using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOnWinMill : MonoBehaviour
{
    private Quaternion m_Rotation;
    Transform _pivot;
    Rigidbody2D _rigidBody;

    void Start()
    {
        m_Rotation = Quaternion.Euler(0f, 0f, 0f);
        _pivot = transform.parent;
        transform.parent = null; transform.localRotation = m_Rotation;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _pivot.position - transform.position;
    }
}
