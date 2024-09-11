using ECS.Code.Components;
using ECS.Code.Events;
using ECS.Code.Utils;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ECS.Code.Rifle.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SystemRifleInputReceiver))]
    public sealed class SystemRifleInputReceiver : UpdateSystem {
    
        private Filter _rifleMoveInputPosition;
        private Filter _rifleMoveInputTouch;
    
        private const string Horizontal = "Horizontal";
        private const float Sensitivity = 0.5f;
        private readonly Vector2 _targetResolutionSensitivity = new(1080, 1920);

        public override void OnAwake()
        {
            _rifleMoveInputPosition = World.Filter.With<ComponentRifleMoveInputPosition>().Build();

            CreateMobileInput();
        }

        private void CreateMobileInput()
        {
            _rifleMoveInputTouch = World.Filter.With<ComponentRifleMoveInputTouch>().Build();

            var e = World.CreateEntity();
            e.AddComponent<ComponentRifleMoveInputTouch>();
        }

        public override void OnUpdate(float deltaTime)
        {
            InputShootReceiver();
            
            InputMoveReceiver();

            var horizontal = GetInput();

            foreach (var e in _rifleMoveInputPosition)
            {
                ref var playerInput = ref e.GetComponent<ComponentRifleMoveInputPosition>();

                playerInput.Horizontal = horizontal;
            }
        }

        private void InputShootReceiver()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                World.GetEvent<EventBulletTrigger>()
                    .NextFrame(new EventBulletTrigger() { });
                Debug.Log("EventBulletTrigger sent");
            }
        }

        private void InputMoveReceiver()
        {
            if (!Input.GetMouseButton(0)) return;

            var e = _rifleMoveInputTouch.First();
        
            ref var inputTouch = ref e.GetComponent<ComponentRifleMoveInputTouch>();

            var currentResolution = UtilScreenResolution.GetResolution();

            var newSensitivity = UtilScreenResolution.GetAxisDivider(Sensitivity, currentResolution.x, _targetResolutionSensitivity.x);

            if (Input.GetMouseButtonDown(0))
            {
                inputTouch.TouchPositionX = Input.mousePosition.x;
            }

            var currentMousePositionX = Input.mousePosition.x;
            var previousMousePositionX = inputTouch.TouchPositionX;

            var delta = (currentMousePositionX - previousMousePositionX) * newSensitivity;

            inputTouch.TouchPositionX = currentMousePositionX;
            inputTouch.DeltaX = delta;
        }

        private float GetInput()
        {
            var e = _rifleMoveInputTouch.First();

            var mobileInput = e.GetComponent<ComponentRifleMoveInputTouch>();

            return mobileInput.DeltaX;
        }
    }
}