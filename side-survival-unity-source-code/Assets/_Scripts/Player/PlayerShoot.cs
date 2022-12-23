using Core.ScriptableObjects;
using UnityEngine;

namespace Core.Player
{
    public sealed class PlayerShoot : MonoBehaviour
    {
        public WeaponData CurrentWeapon 
        {
            get => currentWeapon;
            set 
            {
                currentWeapon = value;

                SetupCurrentWeapon();
            }
        }

        [Header("Classes")]
        [SerializeField] private PlayerBehaviour behaviour;

        [Space(4)]

        [SerializeField] private WeaponData defaultWeapon;
        [SerializeField] private SpriteRenderer weaponHandler;

        private WeaponData currentWeapon;

        //SerializeFields temporários
        [SerializeField] private int currentAmmo;
        [SerializeField] private bool isInfinityAmmo;

        private void OnEnable()
        {
            CurrentWeapon = defaultWeapon;

            behaviour.Input.SubscribeShootAction(Shoot);
        }

        private void SetupCurrentWeapon()
        {
            currentAmmo = currentWeapon.MaxAmmo;
            isInfinityAmmo = currentWeapon.HasInfinityAmmo;

            weaponHandler.sprite = currentWeapon.Graphics;

            Debug.Log($"Weapon Changed to {currentWeapon.Name}");
        }

        public void Shoot()
        {
            if(currentAmmo > 0)
            {
                Debug.Log("Shooting");

                if (!isInfinityAmmo) { currentAmmo--; }
            }
            else if(currentAmmo <= 0)
            {
                CurrentWeapon = defaultWeapon;
            }
        }
    }
}
