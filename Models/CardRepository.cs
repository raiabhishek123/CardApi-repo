using CardServiceApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CardServiceApi.Models
{
    public class CardRepository : ICard
    {
        private readonly CardDbContext _context;

        public CardRepository(CardDbContext context)
        {
            _context = context;
        }

        public async void AddCard(Card card)
        {
           await _context.Cards.AddAsync(card);
            _context.SaveChanges(); 
        }

        public async Task<Card> DeleteCard(Guid id)
        {
            var find = await _context.Cards.FindAsync(id);

            if (find == null) return null;

            _context.Cards.Remove(find);
            await _context.SaveChangesAsync();
            return find;
        }

        public Card GetCardById(Guid id)
        {
            var card = _context.Cards.FirstOrDefault(x => x.Id == id);

            if( card == null) return null;

            return card;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> UpdateCard(Card card)
        {
            Card find = await _context.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
            if (find == null) return null;

            find.CardHolderName = card.CardHolderName;
            find.ExpiryMonth = card.ExpiryMonth;
            find.ExpiryYear = card.ExpiryYear;
            find.CCV = card.CCV;

            await _context.SaveChangesAsync();

            return find;
        }
    }
}
