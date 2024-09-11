using ECS.Code.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ECS.Code.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SystemRifle))]
    public sealed class SystemRifle : UpdateSystem
    {
        private Filter _filterRifles;
        
        public override void OnAwake() 
        {
            _filterRifles = World.Filter
                .With<ComponentRifle>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) 
        {
            foreach (var e in _filterRifles)
            {
                var body = e.GetComponent<ComponentTransform>().Transform;
                
                var moveSpeed = e.GetComponent<ComponentSpeed>().Value;
                var horizontalMove = e.GetComponent<ComponentRifle>().HorizontalMove;
                var rightMoveSpeed = e.GetComponent<ComponentRifle>().RightMoveSpeed;

                var maxHorizontalDistance = e.GetComponent<ComponentRifle>().MaxHorizontalDistance;

                var forward = moveSpeed * body.transform.forward;
                var right = horizontalMove * rightMoveSpeed * body.transform.right;

                HorizontalMoveLimit(maxHorizontalDistance, body.transform.position, ref right);

                body.transform.position += (forward + right) * deltaTime;
                Debug.Log("body transform: " + body.name);
            }
        }
        
        private static void HorizontalMoveLimit(float maxHorizontalDistance, Vector3 playerPosition, ref Vector3 right)
        {
            if (playerPosition.x <= -maxHorizontalDistance && right.x < 0)
            {
                right.x = 0;
                return;
            }
        
            if (playerPosition.x >= maxHorizontalDistance && right.x > 0)
            {
                right.x = 0;
            }
        }
    }
}