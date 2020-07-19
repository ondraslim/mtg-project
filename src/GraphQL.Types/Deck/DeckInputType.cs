namespace GraphQL.Types.Deck
{
    public class DeckInputType : InputObjectGraphType
    {
        public DeckInputType()
        {
            Name = "DeckInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<GuidGraphType>>("userId");
        }
    }
}