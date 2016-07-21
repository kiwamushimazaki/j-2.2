namespace ConsoleApplication1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    internal class Userplayer : Player
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Userplayer"/> class.
        /// 各プレイヤーの手の情報
        /// </summary>
        /// <param name="hand">プレイヤーが選択した手の種類</param>
        public Userplayer(int hand)
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Userplayer"/> class.
        /// プレイヤーの手の情報
        /// </summary>
        public Userplayer()
        {
        }
    }
}
