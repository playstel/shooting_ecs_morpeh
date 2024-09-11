using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ECS.Code.Components
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ComponentRifle : IComponent {

        public float HorizontalMove;
        public float RightMoveSpeed;
        public Transform TransformBulletSpawn;
        public Animation AnimationShoot;
        public ParticleSystem ShootVfx;
        public AudioSource ShootSfx;

        public float MaxHorizontalDistance;
    }
}