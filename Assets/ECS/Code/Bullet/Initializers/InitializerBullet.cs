using ECS.Code.Components;
using ECS.Code.Events;
using ECS.Code.Providers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ECS.Code.Initializers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(InitializerBullet))]
    public sealed class InitializerBullet : Initializer {
        
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField] private ProviderBullet providerBullet;
        [SerializeField] private int bulletsPool = 10;
        private Filter _filterRifles;

        private Event<EventBulletTrigger> OnBulletTrigger = new();
        
        public override void OnAwake() 
        {
            OnBulletTrigger = World.GetEvent<EventBulletTrigger>();
            OnBulletTrigger.Subscribe(OnTrigger);
            
            _filterRifles = World.Filter
                .With<ComponentRifle>()
                .Build();
        }
        
        private void OnTrigger(FastList<EventBulletTrigger> bulletTrigger)
        {
            Debug.Log("On trigger");
            
            var rifle = _filterRifles.FirstOrDefault().GetComponent<ComponentRifle>();

            //if(rifle.AnimationShoot.isPlaying) return;

            rifle.AnimationShoot.Play("Shoot_Anim");
            rifle.ShootSfx.pitch = Random.Range(0.9f, 1.1f);
            rifle.ShootSfx.Play();
            rifle.ShootVfx.Play();
            
            var spawn = rifle.TransformBulletSpawn;
            
            var bullet = Instantiate(providerBullet, null, true);

            bullet.transform.position = spawn.position;
            
            var r = bullet.Entity.GetComponent<ComponentRigidbody>().Body;
            var speed = bullet.Entity.GetComponent<ComponentSpeed>().Value;
            
            r.velocity = bullet.transform.forward * speed;
        }

        public override void Dispose() { }
    }
}