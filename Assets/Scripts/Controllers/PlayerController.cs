using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StarShooter.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Position")]
        [SerializeField] private Vector3 _initialPos = new Vector3 (0,-2,0);

        [Header("Movement")]
        [SerializeField] private float _speed = 5;

        //Properties
        private float ActualSpeed => _speed * Time.deltaTime;
        private float XSpeed => Input.GetAxis("Horizontal")*ActualSpeed;
        private float YSpeed => Input.GetAxis("Vertical")* ActualSpeed;
        private Vector3 MoveDir => new Vector3 (XSpeed,YSpeed,0);

        // Start is called before the first frame update
        void Start()
        {
            // asign or reset the player to the inital position when this scene is loaded.
            transform.position = _initialPos;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //using the old input system to move the player
            Move();
        }

        private void Move()
        {
            transform.Translate(MoveDir);
        }
    }

}
