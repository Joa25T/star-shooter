using System;
using UnityEngine;

namespace StarShooter.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Position")]
        [SerializeField] private Vector3 _initialPos = new Vector3 (0,-2,0);

        [Header("Movement")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _playerBoundsX = 9.37f;
        [SerializeField] private float _playerBoundsYMin = -4.5f;
        [SerializeField] private float _playerBoundsYMax = 0;

        //Properties
        //Movement Properties
        private float ActualSpeed => _speed * Time.deltaTime;
        private float XSpeed => Input.GetAxis("Horizontal")*ActualSpeed;
        private float YSpeed => Input.GetAxis("Vertical")* ActualSpeed;
        private Vector3 MoveDir => new Vector3 (XSpeed,YSpeed,0);

        //Warp Properties
        private float WarpPosX => transform.position.x > 0 ? -_playerBoundsX : _playerBoundsX ;
        private Vector3 WarpPos => new Vector3 (WarpPosX, transform.position.y, 0);
        private Vector3 topBoundry => new Vector3 (transform.position.x, _playerBoundsYMax, 0);
        private Vector3 botBoundry => new Vector3 (transform.position.x, _playerBoundsYMin, 0);

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
            if (MathF.Abs(transform.position.x) > _playerBoundsX)
            {
                transform.position = WarpPos;
            }
            if (transform.position.y > _playerBoundsYMax)
            {
                transform.position = topBoundry;
            }
            else if(transform.position.y < _playerBoundsYMin)
            {
                transform.position = botBoundry;
            }
        }

        private void Move()
        {
            transform.Translate(MoveDir);
        }
    }

}
