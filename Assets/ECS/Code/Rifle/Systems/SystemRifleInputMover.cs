using ECS.Code.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SystemRifleInputMover))]
public sealed class SystemRifleInputMover : UpdateSystem {
    private Filter _rifleMoveInputPosition;
    private Filter _rifleMove;

    public override void OnAwake()
    {
        _rifleMoveInputPosition = World.Filter.With<ComponentRifleMoveInputPosition>().Build();
        _rifleMove = World.Filter.With<ComponentRifle>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        RifleMove();
    }

    private void RifleMove()
    {
        var entity = _rifleMove.First();
        ref var moveComponent = ref entity.GetComponent<ComponentRifle>();
        
        moveComponent.HorizontalMove = GetHorizontalInput();
    }

    private float GetHorizontalInput()
    {
        var e = _rifleMoveInputPosition.First();

        var playerInput = e.GetComponent<ComponentRifleMoveInputPosition>();

        return playerInput.Horizontal;
    }
}