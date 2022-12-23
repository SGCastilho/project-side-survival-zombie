using UnityEngine;

namespace Core.ScriptableObjects
{
    public enum WeaponSpread { DEFAULT, SHOTGUN }

    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/New Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public string Name { get => weaponName; }
        public Sprite Graphics { get => weaponGraphics; }

        public WeaponSpread SpreadType { get => spreadType; }

        public int MaxAmmo { get => weaponAmmo; }
        public int BaseDamage { get => weaponBaseDamage; }

        public bool HasInfinityAmmo { get => hasInfinityAmmo; }

        [Header("Weapon Settings")]
        [SerializeField] private string weaponName = "Weapon";
        [SerializeField] private Sprite weaponGraphics;

        [Space(4)]

        [SerializeField] private WeaponSpread spreadType;

        [Space(4)]

        [SerializeField] [Range(2, 100)] private int weaponAmmo = 64;
        [SerializeField] [Range(10, 100)] private int weaponBaseDamage = 10;

        [Space(4)]

        [SerializeField] private bool hasInfinityAmmo = false;

        #region Editor Variable
#if UNITY_EDITOR
        [Space(10)]

        [SerializeField] [Multiline(6)] private string devNotes = "Put your dev notes here.";
#endif
        #endregion
    }
}
