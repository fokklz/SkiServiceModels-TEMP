namespace SkiServiceModels.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class UpdateTypeAttribute : Attribute
    {
        public Type UpdateType { get; private set; }

        public UpdateTypeAttribute(Type updateType)
        {
            UpdateType = updateType;
        }
    }
}
