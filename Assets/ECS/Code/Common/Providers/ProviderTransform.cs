using ECS.Code.Components;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace ECS.Code.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ProviderTransform : MonoProvider<ComponentTransform> {
    
        private void Reset()
        {
            ref ComponentTransform unityTransform = ref GetData();
            unityTransform.Transform = transform;
        }
    }
}