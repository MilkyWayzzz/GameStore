﻿using GameStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Abstract
{
    public interface IGameQuaries
    {
        GameViewModel Get(int page, int pageSize);
    }
}
