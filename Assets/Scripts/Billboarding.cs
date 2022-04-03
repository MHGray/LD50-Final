using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{

    [SerializeField] static private Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.forward = camTransform.forward;

        float y = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, y, 0f);
    }
}
