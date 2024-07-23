using Microsoft.EntityFrameworkCore;
using TheBazzarTest.Data;
using TheBazzarTest.Entity;

namespace TheBazzarTest.Services;

public class GameService(DataContext context) : IGameService
{
    public async Task<Game> AddGame(Game game)
    {
        var statItem = new Game
        {
            Username = game?.Username ?? string.Empty,
            Email = game?.Email ?? "testEmail@gmail.com",
            CurrentLevel = game?.CurrentLevel ?? 9,
            ExperiencePoints = game?.ExperiencePoints ?? 9,
            ExperiencePointsToNextLevel = game?.ExperiencePointsToNextLevel ?? 9,
            TotalGamesPlayed = game?.TotalGamesPlayed ?? 9,
            TotalWins = game?.TotalWins ?? 9,
            TotalLosses = game?.TotalLosses ?? 9,
            FriendsCount = game?.FriendsCount ?? 9,
            MessagesSent = game?.MessagesSent ?? 9,
            MessagesReceived = game?.MessagesReceived ?? 9
        };
        
        context.Games.Add(statItem);
        await context.SaveChangesAsync();

        return statItem;
    }

    public async Task<bool> DeleteGame(int id)
    {
        var dbGame = await context.Games.FindAsync(id);
        if(dbGame != null)
        {
            context.Remove(dbGame);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Game> EditGame(int id, Game game)
    {
        var dbGame = await context.Games.FindAsync(id);
        if(dbGame != null)
        {
            dbGame.Username = game.Username;
            await context.SaveChangesAsync();
            return dbGame;
        }
        throw new Exception("Game not found.");
    }

    public async Task<List<Game>> GetAllGames()
    {
        var games = await context.Games.ToListAsync();
        return games;
    }

    public async Task<Game> GetGameById(int id)
    {
        return await context.Games.FindAsync(id);
    }
}