﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces {
    public interface IPostService {
        IEnumerable<Post> GetPosts ();
        Task<Post> GetPost (int id);
        Task InsertPost (Post post);
        bool UpdatePost (Post post);
        Task<bool> DeletePost (int id);
    }
}