namespace SolidMapper.Conditions
{
    public sealed class RecursionCondition : IMappingCondition
    {
        public bool ShouldMap<T>(T property,
                                 IMappingContext context)
        {
            if (context == null)
            {
                return true;
            }

            foreach (var item in context.Tree)
            {
                if (item.Equals(property))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
