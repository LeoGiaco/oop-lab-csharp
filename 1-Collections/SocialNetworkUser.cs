using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private IDictionary<string, IList<TUser>> _groups;
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            Groups = new Dictionary<string, IList<TUser>>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if(!Groups.ContainsKey(group))
                Groups.Add(group, new List<TUser>() { user });
            else
            {
                if(! Groups[group].Contains(user))
                    Groups[group].Add(user);
                else return false;
            }
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                ISet<TUser> set = new HashSet<TUser>();
                foreach(IList<TUser> l in Groups.Values)
                    set.UnionWith(l);
                return set.ToList();
            }
        }

        private IDictionary<string, IList<TUser>> Groups
        {
            get => _groups;
            set => _groups = value;
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if(Groups.ContainsKey(group))
                return Groups[group];
            else
                return new List<TUser>();
        }
    }
}
