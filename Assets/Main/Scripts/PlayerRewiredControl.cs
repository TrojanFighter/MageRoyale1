using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using Rewired;

namespace MageRoyale
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerRewiredControl : MonoBehaviour
    {
        public int playerId = 0; // The Rewired player id of this character

        //public float moveSpeed = 3.0f;
        //public float bulletSpeed = 15.0f;

        private Player player; // The Rewired Player
        private Vector3 moveVector;
        private bool fire;
        
        [System.NonSerialized] // Don't serialize this so the value is lost on an editor script recompile.
        private bool initialized;

        public bool bturnwithMouse;
        
        public float Ease = .15f;

        Transform _transform;

        
        public float RunSpeed = 12;
        public float Acceleration = 30;

        float _currentSpeedH;
        float _currentSpeedV;
        Vector3 _amountToMove;
        int _totalJumps;

        CharacterController _characterController;

        bool _movementAllowed = true;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _transform = transform;

            var cinematics = FindObjectsOfType<ProCamera2DCinematics>();
            for (int i = 0; i < cinematics.Length; i++)
            {
                cinematics[i].OnCinematicStarted.AddListener(() =>
                    {
                        _movementAllowed = false; 
                        _currentSpeedH = 0;
                        _currentSpeedV = 0;
                    });

                cinematics[i].OnCinematicFinished.AddListener(() =>
                    {
                        _movementAllowed = true; 
                    });
            }
        }
        
        private bool Initialize() {
            // Get the Rewired Player object for this player.
            player = ReInput.players.GetPlayer(playerId);
            
            initialized = true;
            return true;
        }

        void Update() {
            if(!ReInput.isReady) return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
            if(!initialized) Initialize(); // Reinitialize after a recompile in the editor

            GetInput();
            ProcessInput();
            TurnWithMouse();
        }
        
        private void GetInput() {
            // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
            // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

            moveVector.x = player.GetAxis("Horizontal Move"); // get input by name or action id
            moveVector.y = player.GetAxis("Vertical Move");
            
            //Debug.Log(player.GetAxis("Horizontal Move")+" "+player.GetAxis("Vertical Move"));
            //fire = player.GetButtonDown("Fire");
        }

        private void ProcessInput() {
            
            // Process movement
            if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
                
                var targetSpeedH = moveVector.x * RunSpeed;
                _currentSpeedH = IncrementTowards(_currentSpeedH, targetSpeedH, Acceleration);

                var targetSpeedV = moveVector.y * RunSpeed;
                _currentSpeedV = IncrementTowards(_currentSpeedV, targetSpeedV, Acceleration);

                _amountToMove.x = _currentSpeedH;
                _amountToMove.z = _currentSpeedV;

                _characterController.Move(_amountToMove * Time.deltaTime);
                //_characterController.Move(moveVector * moveSpeed * Time.deltaTime);
            }

            /*
            // Process fire
            if(fire) {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
            }*/
        }

        private void TurnWithMouse()
        {
            if (bturnwithMouse)
            {
                if (playerId == 0)
                {
                    var mouse = Input.mousePosition;
                    var screenPoint = Camera.main.WorldToScreenPoint(_transform.localPosition);
                    var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
                    var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
                    _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.Euler(0, -angle, 0), Ease);
                }
            }
        }
/*
        void Update()
        {
            if (!_movementAllowed)
                return;

            var targetSpeedH = Input.GetAxis("Horizontal") * RunSpeed;
            _currentSpeedH = IncrementTowards(_currentSpeedH, targetSpeedH, Acceleration);

            var targetSpeedV = Input.GetAxis("Vertical") * RunSpeed;
            _currentSpeedV = IncrementTowards(_currentSpeedV, targetSpeedV, Acceleration);

            _amountToMove.x = _currentSpeedH;
            _amountToMove.z = _currentSpeedV;

            _characterController.Move(_amountToMove * Time.deltaTime);
        }*/

        // Increase n towards target by speed
        private float IncrementTowards(float n, float target, float a)
        {
            if (n == target)
            {
                return n;   
            }
            else
            {
                float dir = Mathf.Sign(target - n); 
                n += a * Time.deltaTime * dir;
                return (dir == Mathf.Sign(target - n)) ? n : target;
            }
        }
    }
}