using UnityEngine;

namespace Core.Player
{
    public sealed class PlayerBehaviour : MonoBehaviour
    {
        public PlayerInputs Input { get => _playerInputs; }
        public PlayerAimWeapon Aim { get => _playerAimWeapon; }
        public PlayerMoviment Moviment { get => _playerMoviment; }

        [Header("Classes")]
        [SerializeField] private PlayerInputs _playerInputs;
        [SerializeField] private PlayerAimWeapon _playerAimWeapon;
        [SerializeField] private PlayerMoviment _playerMoviment;
    }
}
