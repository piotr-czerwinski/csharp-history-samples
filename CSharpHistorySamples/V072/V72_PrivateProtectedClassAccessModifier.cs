namespace CSharpHistorySamples;

internal static partial class V72
{
    public class BaseWithPrivateProtectedMember 
    {
        // private protected members (added in 7.2) are accessible from derived class from base class assembly only
        // protected internal configuration makes member accessible from any class of the base class assembly
        // and all derived class from any
        private protected void PrivateProtectedMethod() { }
        protected internal void ProtectedInternalMethod() { }
    }

    internal class DerivedFromBaseWithPrivateProtectedMember : BaseWithPrivateProtectedMember
    {
        internal void M()
        {
            PrivateProtectedMethod(); // only valid for base derived class existing in base class assembly
            ProtectedInternalMethod(); // would also be accessible if Derived class exist in other assembly
        }
    }
    internal class OtherClass
    {
        private void M()
        {
            var baseClassInstance = new BaseWithPrivateProtectedMember();
            // baseClassInstance.PrivateProtectedMethod(); not accessible
            baseClassInstance.ProtectedInternalMethod();
        }
    }
}
