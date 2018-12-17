namespace StableMapper
{
    public interface IMapper<TDTO, TEntity>
    {
        TEntity MapFrom(TDTO contactMethodEdit);
        TDTO MapTo(TEntity method);
        void Update(TEntity source, TDTO target);
        void Update(TDTO source, TEntity target);
    }
}