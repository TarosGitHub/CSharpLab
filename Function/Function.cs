using System;

namespace Functions
{
    /**
     * <summary>
     * 関数クラス
     * </summary>
     * <member name="order">次数</member>
     * <member name="unknown">未知数の数</member>
     */
    public abstract class Function
    {
        private int order;
        private int unknown;

        /**
         * <summary>
         * コンストラクタ
         * </summary>
         * <param name="order">次数</param>
         * <param name="unknown">未知数の数</param>
         */
        protected Function(int order, int unknown)
        {
            this.order = order;
            this.unknown = unknown;
        }

        /**
         * <summary>
         * プロパティ Order
         * </summary>
         */
        public int Order
        {
            get
            {
                return this.order;
            }
        }

        /**
         * <summary>
         * プロパティ Unknown
         * </summary>
         */
        public int Unknown
        {
            get
            {
                return this.unknown;
            }
        }

        /**
         * <summary>
         * 関数の実行
         * </summary>
         * <param name="x">引数</param>
         */
        public abstract double Execute(params double[] x);

    } // class Function

} // namespace Functions
