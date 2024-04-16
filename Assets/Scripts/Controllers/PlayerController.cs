using UnityEngine;

namespace StarShooter.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Position")]
        [SerializeField] private Vector3 _initialPos = new Vector3 (0,-2,0);

        [Header("Movement")]
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _topBoundry = 0;
        [SerializeField] private float _botBoundry = -4.5f;
        [SerializeField] private float _warpWidth = 9.4f;

        //Properties
        private float ActualSpeed => _speed * Time.deltaTime;
        private float XSpeed => Input.GetAxis("Horizontal")*ActualSpeed;
        private float YSpeed => Input.GetAxis("Vertical")* ActualSpeed;
        private Vector3 MoveDir => new Vector3 (XSpeed,YSpeed,0);

        //storing the players X position and boundries to stop the player form going out of bounds
        private Vector3 TopBoundry => new Vector3(transform.position.x, _topBoundry, 0);
        private Vector3 BotBoundry => new Vector3(transform.position.x, _botBoundry, 0);

        //Warping if the players position is bigger than 1 it needs to go to -_warpWidth and viceversa
        private float WarpPosX => transform.position.x > 0 ? -_warpWidth : _warpWidth;
        private Vector3 WarpPos => new Vector3(WarpPosX, transform.position.y, 0);


        // Start is called before the first frame update
        void Start()
        {
            SetInitialPosition();
        }

        private void SetInitialPosition()
        {
            // asign or reset the player to the inital position when this scene is loaded.
            transform.position = _initialPos;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //using the old input system to move the player
            Move();
            Warp();
        }

        private void Warp()
        {
            if (Mathf.Abs(transform.position.x)> _warpWidth) 
            {
                transform.position = WarpPos;
            }
        }

        private void Move()
        {
            //Vector3 moveDir = new Vector3(dirX)
            transform.Translate(MoveDir);
            if(transform.position.y > _topBoundry)
            {
                transform.position = TopBoundry;
                return;
            }
            else if(transform.position.y < _botBoundry)
            {
                transform.position = BotBoundry; 
                return;
            }
        }
    }
}
