namespace CSharpHistorySamples.V09;

internal static partial class V9
{
    internal static void CovariantReturnTypes()
    {
        var cat = new Cat();
        var catClone = cat.Clone();

        // before C# 9 Clone would return Animal and Cast would be required:
        // var catClone = (Cat)cat.Clone();
    }

    class Animal
    {
        public virtual Animal Clone() => new();
    }

    class Cat : Animal
    {
        // can return Cat instead of Animal as before C# 9
        public override Cat Clone() => new();
    }
}
