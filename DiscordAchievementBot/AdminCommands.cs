﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiscordAchievementBot
{
    [RequireOwner()]
    public class AdminCommands : ModuleBase
    {
        [Command("Debug")]
        [Summary("Replies back with some debug info about the bot.")]
        public async Task DebugInfo()
        {
            await ReplyAsync(
                $"{Format.Bold("Info")}\n" +
                $"- D.NET Lib Version {DiscordConfig.Version} (API v{DiscordConfig.APIVersion})\n" +
                $"- Runtime: {RuntimeInformation.FrameworkDescription} {RuntimeInformation.OSArchitecture}\n" +
                $"- Heap: {GetHeapSize()} MB\n" +
                $"- Uptime: {GetUpTime()}\n\n" +
                $"- Guilds: {(Context.Client as DiscordSocketClient).Guilds.Count}\n" +
                $"- Channels: {(Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Channels.Count)}\n" +
                $"- Users: {(Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Users.Count)}"
                );
        }

        private static string GetUpTime()
            => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
        private static string GetHeapSize()
=> Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();
    }
}