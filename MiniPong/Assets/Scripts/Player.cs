using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string axisName;
    [SerializeField] private float speed;
    [SerializeField] float verticalLimitMax, verticalLimitMin;
    void Update()
    {
        float move = Input.GetAxis(axisName) * speed;

        float nextPlayerPositionY = transform.position.y + (move * Time.deltaTime);
        float clampedPositionY = Mathf.Clamp(nextPlayerPositionY, verticalLimitMin, verticalLimitMax);
        transform.position = new Vector3(transform.position.x, clampedPositionY, transform.position.z);
    }
}