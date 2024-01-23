namespace SkiServiceModels.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CreateTypeAttribute : Attribute
    {
        public Type CreateType { get; private set; }

        public CreateTypeAttribute(Type createType)
        {
            CreateType = createType;
        }
    }
}
