// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApplication1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// コンピュータを作るクラス
    /// </summary>
    class CpuCreator : AbstractCreator
    {
        public override Player Create()
        {
            return new Cpuplayer();
        }
    }

}
