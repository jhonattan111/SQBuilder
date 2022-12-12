namespace SQBuilder.Enums
{
    public enum EJoinTypes : int
    {
        Join = 1,
        LeftJoin = 2,
        RightJoin = 4,
        InnerJoin = 8,
        LeftOuterJoin = 16,
        RightOuterJoin = 32,
    }
}
