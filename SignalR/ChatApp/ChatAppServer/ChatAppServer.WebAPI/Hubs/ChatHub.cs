using ChatAppServer.WebAPI.Context;
using ChatAppServer.WebAPI.Enums;
using ChatAppServer.WebAPI.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChatAppServer.WebAPI.Hubs;

public sealed class ChatHub(
    ApplicationDbContext context) : Hub
{
    public static Dictionary<string, int> Users = new();

    public async Task Connect(int userId)
    {
        if(Users.Any(p=> p.Value == userId))
        {
            string key = Users.First(p => p.Value == userId).Key;

            Users.Remove(key);
        }

        Users.Add(Context.ConnectionId, userId);
        

        User? user = await context.Users.FindAsync(userId);
        if (user is null) return;

        user.Status = UserStatusEnum.Online;

        context.Users.Update(user);
        await context.SaveChangesAsync();

        await Clients.All.SendAsync("Users", user);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        bool result = Users.TryGetValue(Context.ConnectionId, out int userId);
        if (result)
        {
            User? user = await context.Users.FirstOrDefaultAsync(p=> p.Id ==  userId);
            if (user is null) return;

            Users.Remove(Context.ConnectionId);

            user.Status = UserStatusEnum.Offline;

            context.Update(user);
            await context.SaveChangesAsync();

            await Clients.All.SendAsync("Users", user);
        }
    }
}
