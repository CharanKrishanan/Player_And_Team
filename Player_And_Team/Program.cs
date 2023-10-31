using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_And_Team
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    public interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();

        public OneDayTeam()
        {
            oneDayTeam = new List<Player>();
        }

        public void Add(Player player)
        {
            if (oneDayTeam.Count < 11)
            {
                oneDayTeam.Add(player);
                Console.WriteLine("Player added successfully.");
            }
            else
            {
                Console.WriteLine("The team is already full. You cannot add more players.");
            }
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine("Player removed successfully.");
            }
            else
            {
                Console.WriteLine("Player not found in the team.");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.Find(p => p.PlayerName == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return oneDayTeam;
        }
    }

    class Program
    {
        static void Main()
        {
            OneDayTeam oneDayTeam = new OneDayTeam();
            int choice;
            string continueChoice;

            do
            {
                Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Player Id: ");
                            int playerId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Player Name: ");
                            string playerName = Console.ReadLine();
                            Console.Write("Enter Player Age: ");
                            int playerAge = int.Parse(Console.ReadLine());

                            Player newPlayer = new Player
                            {
                                PlayerId = playerId,
                                PlayerName = playerName,
                                PlayerAge = playerAge
                            };

                            oneDayTeam.Add(newPlayer);
                            break;
                        case 2:
                            Console.Write("Enter Player Id to Remove: ");
                            int idToRemove = int.Parse(Console.ReadLine());
                            oneDayTeam.Remove(idToRemove);
                            break;
                        case 3:
                            Console.Write("Enter Player Id to Get: ");
                            int idToGet = int.Parse(Console.ReadLine());
                            Player playerById = oneDayTeam.GetPlayerById(idToGet);
                            if (playerById != null)
                            {
                                Console.WriteLine($"Player Id: {playerById.PlayerId}, Name: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found.");
                            }
                            break;
                        case 4:
                            Console.Write("Enter Player Name to Get: ");
                            string nameToGet = Console.ReadLine();
                            Player playerByName = oneDayTeam.GetPlayerByName(nameToGet);
                            if (playerByName != null)
                            {
                                Console.WriteLine($"Player Id: {playerByName.PlayerId}, Name: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found.");
                            }
                            break;
                        case 5:
                            List<Player> allPlayers = oneDayTeam.GetAllPlayers();
                            foreach (var player in allPlayers)
                            {
                                Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.Write("Do you want to continue (yes/no)? ");
                continueChoice = Console.ReadLine().ToLower();
            } while (continueChoice == "yes");
        }
    }
}
