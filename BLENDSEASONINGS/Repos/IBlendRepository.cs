﻿using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IBlendRepository
    {
        List<Blend> GetAllBlends();
        Blend GetBlendById(int id);
    }
}
