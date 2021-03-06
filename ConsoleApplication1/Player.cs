﻿// <copyright file="Player.cs" company="PlaceholderCompany">
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
    /// プレイヤー全体の基本情報を含むクラス
    /// </summary>
    internal abstract class Player
    {
        private int hand;

        public int Hand
        {
            get
            {
                return this.hand;
            }

            set
            {
                this.hand = value;
            }
        }
    }
}
