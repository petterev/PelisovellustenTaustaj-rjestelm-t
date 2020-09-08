using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment2
{

    delegate Item Transformer(Item i);
    class Program
    {

        static void Main(string[] args)
        {
            List<Item> l = new List<Item>();
            l.Add(new Item(100));
            l.Add(new Item(10));
            l.Add(new Item(14));
            l.Add(new Item(78));
            l.Add(new Item(120));

            Player player = new Player(l);

            Console.WriteLine("Level of highest level item: " + player.GetHighestLevelItem().Level);

            //Tehtävä 3 tulostus
            Console.WriteLine(GetItem(player));
            Console.WriteLine(GetItemsWithLinq(player));
            //Tehtävä 4 tulostus
            Console.WriteLine(FirstItem(player).Level);
            Console.WriteLine(FirstItemWithLinq(player).Level);

            Action<Item> process = PrintItem;
            ProcessEachItem(player, process);

            //Tehtävä 6
            Action<Item> delegateInstance = (Item i) =>
            {
                Console.WriteLine("ID: " + i.Id);
                Console.WriteLine("LEVEL: " + i.Level);
            };
            ProcessEachItem(player, delegateInstance);

            //Tehtävä 7
            List<Player> p = new List<Player>();

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                p.Add(new Player(rnd.Next(0, 100)));

            }

            List<PlayerForAnotherGame> p2 = new List<PlayerForAnotherGame>();

            for (int i = 0; i < 10; i++)
            {
                p2.Add(new PlayerForAnotherGame(rnd.Next(0, 100)));

            }

            Game<Player> game1 = new Game<Player>(p);
            Console.WriteLine(game1.GetTop10Players());

            Game<PlayerForAnotherGame> game2 = new Game<PlayerForAnotherGame>(p2);
            Console.WriteLine(game2.GetTop10Players());



        }

        public static Item[] GetItem(Player p)
        {
            Item[] items = new Item[p.Items.Count];

            for (int x = 0; x < items.Length; x++)
            {
                items[x] = p.Items[x];
            }

            return items;

        }

        public static Item[] GetItemsWithLinq(Player p)
        {
            Item[] items = p.Items.ToArray();

            return items;
        }

        public static Item FirstItem(Player p)
        {
            if (p.Items.Count == 0)
                return null;

            return p.Items[0];
        }
        public static Item FirstItemWithLinq(Player p)
        {
            if (p.Items.Count == 0)
                return null;

            return p.Items.First();
        }

        public static void ProcessEachItem(Player player, Action<Item> process)
        {
            if (player != null)
            {
                foreach (Item itm in player.Items)
                    process(itm);
            }
        }


        public static void PrintItem(Item item)
        {
            Console.WriteLine("ID: " + item.Id);
            Console.WriteLine("LEVEL: " + item.Level);

        }




        //Tehtävä 1
        public static List<Player> GeneratePlayers()
        {
            List<Player> players = new List<Player>();
            bool same;
            for (int i = 0; i < 1000000; i++)
            {

                while (true)
                {
                    same = false;
                    Guid g = Guid.NewGuid();
                    foreach (Player p in players)
                    {
                        if (g == p.Id)
                        {
                            same = true;
                            break;
                        }
                    }
                    if (!same)
                    {
                        players[i] = new Player(g);
                        break;
                    }

                }

            }
            return players;
        }




    }
}


