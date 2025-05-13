using System.Net.WebSockets;

namespace InheritanceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var cards = new Card[3];

            cards[0] = new RegularCard(5000);
            cards[1] = new GoldCard(500_000, 14.3M);
            cards[2] = new GoldCard(1_500_000, 28.9M);

            foreach (var card in cards)
            {
                card.Pay(500M);
                
                //if (card is Card forSureGoldCard)
                //{
                //    //var forSureGoldCard = (GoldCard) card; // invalidcastexception if not goldcard
                //    /*var forSureGoldCard = card as GoldCard; */// return null if not goldcard
                //    //if (forSureGoldCard is not null)
                //    //{
                //}
                //}

                Console.WriteLine("=========");
            }
        }
    }
}
