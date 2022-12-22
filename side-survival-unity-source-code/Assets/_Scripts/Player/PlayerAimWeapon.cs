using UnityEngine;

namespace Core.Player
{
    public sealed class PlayerAimWeapon : MonoBehaviour
    {
        [Header("Classes")]
        [SerializeField] private PlayerBehaviour behaviour;

        [Header("Settings")]
        [SerializeField] private Transform aimPivot;

        [Space(6)]

        [SerializeField] private SpriteRenderer graphicToFlip;

        public float AimAngle { get => _aimAngle; }

        private float _aimAngle;
        private Vector3 _aimDirection;
        private Vector3 _aimEulerAngles;

        private void Update()
        {
            PointAimToMousePosistion();
            FlipGraphicsBasedInWeaponAngle();
        }

        private void PointAimToMousePosistion()
        {
            _aimDirection = (behaviour.Input.MouseWorldPosistion - transform.position).normalized;
            _aimAngle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;

            _aimEulerAngles = new Vector3(0, 0, _aimAngle);

            aimPivot.eulerAngles = _aimEulerAngles;
        }

        private void FlipGraphicsBasedInWeaponAngle()
        {
            if (graphicToFlip == null) return;

            if (_aimAngle > 90f || _aimAngle < -90f)
            {
                graphicToFlip.flipX = true;
            }
            else { graphicToFlip.flipX = false; }
        }
    }
}
