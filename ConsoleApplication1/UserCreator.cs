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
    /// ユーザーを作るクラス
    /// </summary>
    class UserCreator : AbstractCreator
    {
        public override Player Create()
        {
            return new Userplayer();
        }
    }

}
