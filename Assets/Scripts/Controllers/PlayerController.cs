using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace StarShooter.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Position")]
        [SerializeField] private Vector3 _initialPos = new Vector3 (0,-2,0);

        [Header("Movement")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _playerBounds = 9.37f;

        //Properties
        //Movement Properties
        private float ActualSpeed => _speed * Time.deltaTime;
        private float XSpeed => Input.GetAxis("Horizontal")*ActualSpeed;
        private float YSpeed => Input.GetAxis("Vertical")* ActualSpeed;
        private Vector3 MoveDir => new Vector3 (XSpeed,YSpeed,0);

        //Warp Properties
        private float WarpPosX => transform.position.x > 0 ? -_playerBounds : _playerBounds ;
        private Vector3 WarpPos => new Vector3 (WarpPosX, transform.position.y, 0);

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
            WarpPlayer();
        }

        private void WarpPlayer()
        {
            if (MathF.Abs(transform.position.x) > _playerBounds)
            {
                transform.position = WarpPos;
            }
        }

        private void Move()
        {
            transform.Translate(MoveDir);
        }
    }

}
