namespace CardServiceApi.Models
{
    public interface ICard
    {
         Task<IEnumerable<Card>> GetCards();

        Card GetCardById(Guid id);

        void AddCard(Card card);    

        Task<Card> UpdateCard(Card card);

        Task<Card> DeleteCard(Guid id);
    }
}
