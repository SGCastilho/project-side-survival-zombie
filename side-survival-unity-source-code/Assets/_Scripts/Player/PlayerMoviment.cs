using UnityEngine;

namespace Core.Player
{
    public sealed class PlayerMoviment : MonoBehaviour
    {
        [Header("Classes")]
        [SerializeField] private PlayerBehaviour _behaviour;

        [Space(6)]

        [SerializeField] private Rigidbody2D _rb2D;

        [Header("Settings")]
        [SerializeField] private float _movimentSpeed = 5f;
        [SerializeField] private float _jumpForce = 60f;

        [Space(6)]

        [SerializeField][Range(0.1f, 1f)] private float _groundCheckRange = 0.2f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheckTransform;

        #region EditorVariable
#if UNITY_EDITOR
        [SerializeField] private bool _showGroundCheckGizmos;
#endif
        #endregion

        [SerializeField] private bool _isGrounded;

        private Vector2 _xVelocity;
        private Vector2 _finalVelocity;

        private void OnEnable() => SetupInputs();

        private void SetupInputs()
        {
            _behaviour.Input.SubscribeJumpAction(Jump);
        }

        private void Update()
        {
            GroundCheck();
            Moviment();
        }

        private void Moviment()
        {
            _xVelocity = Vector2.right * _behaviour.Input.HorizontalAxis * _movimentSpeed;
            _finalVelocity = new Vector2(_xVelocity.x, _rb2D.velocity.y);

            _rb2D.velocity = _finalVelocity;
        }

        private void GroundCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRange, _groundLayer) ? true : false;
        }

        public void Jump()
        {
            if(_isGrounded)
            {
                _rb2D.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }

        #region Editor Gizmos
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if(_showGroundCheckGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_groundCheckTransform.position, _groundCheckRange);
            }
        }
#endif
        #endregion
    }
}
