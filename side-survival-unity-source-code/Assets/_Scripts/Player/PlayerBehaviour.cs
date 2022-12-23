using UnityEngine;

namespace Core.Player
{
    public sealed class PlayerBehaviour : MonoBehaviour
    {
        public PlayerInputs Input { get => _playerInputs; }
        public PlayerShoot Shoot { get => _playerShoot; }
        public PlayerAimWeapon Aim { get => _playerAimWeapon; }
        public PlayerMoviment Moviment { get => _playerMoviment; }

        [Header("Classes")]
        [SerializeField] private PlayerInputs _playerInputs;
        [SerializeField] private PlayerShoot _playerShoot;
        [SerializeField] private PlayerAimWeapon _playerAimWeapon;
        [SerializeField] private PlayerMoviment _playerMoviment;
    }
}
