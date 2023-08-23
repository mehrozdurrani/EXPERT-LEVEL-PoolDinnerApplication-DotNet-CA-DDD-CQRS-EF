﻿using PoolDinner.Domain.UserAggregate;

namespace PoolDinner.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}

