using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 eulerRotation;
    [SerializeField] private float damping;

    /*public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    Camera camera;*/

    private void Start() 
    {
        //camera =  GetComponent<Camera>();
        //transform.eulerAngles = eulerRotation;
        if (target == null)
            return;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, damping * Time.deltaTime);
        //transform.LookAt(target.transform.position);

        /*if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }*/

    }

    
}