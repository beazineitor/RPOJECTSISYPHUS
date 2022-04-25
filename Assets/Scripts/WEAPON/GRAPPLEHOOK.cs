using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAPPLEHOOK : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _grapplignHook;
    [SerializeField] private Transform _grapplingHookEndPoint;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _handPos;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private LayerMask _grappleLayer;
    [SerializeField] public float _maxGrappledistance;
    [SerializeField] public float _hookSpeed;
    [SerializeField] private Vector3 _offset;
    private bool isShooting, isGrappling;
    private Vector3 _hookPoint;
    
    
    private void Start()
    {
        isShooting = false;
        isGrappling = false;
        _lineRenderer.enabled = false;
        
        //create a new variable that saves the local position of the grapple
    }
    private void Update()
    {
        if(_grapplignHook.parent == _handPos)
        {
             _grapplignHook.localPosition = new Vector3 (0.1196709f, 1.482666f, 0.7207371f);
            _grapplignHook.localRotation = Quaternion.Euler (new Vector3(0,0,0));

            

        }
        if (Input.GetMouseButtonDown(0))
        {
            ShootHook();
        }
        if (isGrappling)
        {
            _grapplignHook.position = Vector3.Lerp(_grapplignHook.position, _hookPoint, _hookSpeed*Time.deltaTime);
            if(Vector3.Distance(_grapplignHook.position, _hookPoint) < 0.5f){
                _controller.enabled = false;
                _playerBody.position = Vector3.Lerp(_playerBody.position, _hookPoint - _offset, _hookSpeed * Time.deltaTime);
                if (Vector3.Distance(_playerBody.position, _hookPoint - _offset) < 0.5f)
                {
                    _controller.enabled = true;
                    isGrappling = false;
                    _grapplignHook.SetParent(_handPos);
                    _lineRenderer.enabled = false;
                }
            }
        }
        
    }

    private void LateUpdate()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, _grapplingHookEndPoint.position);
            _lineRenderer.SetPosition(0,_handPos.position);
        }
    }
    private void ShootHook()
    {
        if (isShooting || isGrappling) return;
        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, _maxGrappledistance, _grappleLayer))
        {
            _hookPoint = hit.point;
            isGrappling = true;
            _grapplignHook.parent = null;
            _grapplignHook.LookAt(_hookPoint);
            _lineRenderer.enabled = true; 
            print("HIT");
        }
        isShooting = false;

    }
}
