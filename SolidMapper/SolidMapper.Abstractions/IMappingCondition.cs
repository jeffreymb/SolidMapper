namespace SolidMapper
{
    public interface IMappingCondition
    {
        bool ShouldMap<T>(T property, IMappingContext context);
    }
}
