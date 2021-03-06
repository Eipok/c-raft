﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chraft.Entity;

namespace Chraft.Commands
{
    public class CmdSpawnMob : ClientCommand
    {
        public ClientCommandHandler ClientCommandHandler { get; set; }

        public void Use(Client client, string[] tokens)
        {
            MobType type;
            int amount = 1;
            if(tokens.Length > 2)amount = parseint(tokens[2]);
            try
            {
                type = (MobType) Enum.Parse(typeof(MobType), tokens[1].ToString(), true);
            }
            catch (Exception e) { client.Logger.Log(e); type = MobType.Sheep; }
            for (int i = 0; i < amount; i++)
            {
                client.World.SpawnMob((int)client.Position.X, (int)client.Position.Y, (int)client.Position.Z, type);
            }
        }
        private int parseint(string s)
        {
            int r;
            try
            {
                r = int.Parse(s);
            }
            catch { r = 1; }
            return r;
        }
        public void Help(Client client)
        {
            client.SendMessage("/spawnmob <Mob> [Amount] - Spawns a pig at your position.");
        }

        public string Name
        {
            get { return "spawnmob"; }
        }

        public string Shortcut
        {
            get { return ""; }
        }

        public CommandType Type
        {
            get { return CommandType.Mod; }
        }
    }
}
