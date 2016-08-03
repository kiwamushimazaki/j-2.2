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
    /// プレーヤーを作るクラスを作るクラス
    /// </summary>
    class CreateCreator
    {
        private AbstractCreator usercreator = new UserCreator();
        private AbstractCreator cpucreator = new CpuCreator();

        // public Player Createuser()
        // {
        //    return this.usercreator.Create();
        // }
        // public Player Creatcpu()
        // {
        //    return this.cpucreator.Create();
        // }
        public Player CreatePlayer(string playerType)
        {
            switch (playerType)
            {
                case "User": return this.usercreator.Create();
                case "Cpu": return this.cpucreator.Create();
                default: return null;
            }
        }
    }

}
