using Scellecs.Morpeh;
using TriInspector;
using Unity.IL2CPP.CompilerServices;

namespace ECS.Code.Components
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ComponentRifleMoveInputPosition : IComponent
    {
        [ReadOnly] public float Horizontal;
    }
}