// <copyright file="Exist.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;

    /// <summary>
    /// 各プレーヤーの手を集計するクラス
    /// </summary>
    internal class Exist
    {
        /// <summary>
        /// それぞれの手が存在するかどうかを判断するメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報</param>
        /// <param name="targetHand">注目する手の種類</param>
        /// <returns>bool</returns>
        public static bool HandExist(List<Player> playerList, int targetHand)
        {
            foreach (var hand in playerList)
            {
                if (hand.Hand == targetHand)
                {
                    return true;
                }
            }

            return false;
        }
    }
}