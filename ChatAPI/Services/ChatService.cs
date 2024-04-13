﻿using System.Collections.Generic;
using System.Linq;

namespace ChatAPI.Services
{
    public class ChatService
    {
        private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();

        public bool AddUserToList(string userToAdd) 
        {
            lock(Users)
            {
                foreach (var user in Users)
                {
                    if (user.Key.ToLower() == userToAdd.ToLower()) 
                    {
                        return false;
                    }
                }
                Users.Add(userToAdd, null);
                return true;
            }
        }

        public void AddUserConnectionId(string user, string connectionID) 
        {
            lock (Users) 
            {
                if (Users.ContainsKey(user))
                {
                    Users[user] = connectionID;
                }
            }
        }

        public string GetUserByConnectionId(string connectionID) 
        {
            lock (Users) 
            {
                return Users.Where(x => x.Value == connectionID).Select(x => x.Key).FirstOrDefault();
            }
        }

        public string GetConnectionIdByUser(string user)
        {
            lock (Users)
            {
                return Users.Where(x => x.Key == user).Select(x => x.Value).FirstOrDefault();
            }
        }

        public void RemoveUserFromList(string user) 
        {
            lock (Users) 
            {
                if (Users.ContainsKey(user))
                {
                    Users.Remove(user);
                }
            }
        }

        public string[] GetOnLineUsers() 
        {
            lock (Users)
            {
                return Users.OrderBy(x => x.Key).Select(x => x.Key).ToArray();
            }
        }
    }
}
