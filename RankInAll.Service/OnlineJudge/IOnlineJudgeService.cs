﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Service.OnlineJudge
{
    public interface IOnlineJudgeService
    {
        void Update();
        bool Daily();
    }
}
