using System;

namespace Matrices
{
    /**
     * <summary>
     * 行列の行と列の型
     * </summary>
     */
    using matidx_t = Int32;

    /**
     * <summary>
     * 行列の要素の型
     * </summary>
     */
    using matelem_t = Double;

    /**
     * <summary>
     * 行列クラス
     * </summary>
     * <member name="row">行</member>
     * <member name="col">列</member>
     * <member name="elems">要素</member>
     */
    public class Matrix
    {
        private matidx_t row;
        private matidx_t col;
        private matelem_t[,] elems;

        /**
         * <summary>
         * コンストラクタ Row Col
         * </summary>
         * <param name="row">行</param>
         * <param name="col">列</param>
         */
        public Matrix(matidx_t row, matidx_t col)
        {
            // ToDo: row=0は例外
            // ToDo: col=0は例外
            this.row = row;
            this.col = col;
            this.elems = new matelem_t[row, col];
        }

        /**
         * <summary>
         * コンストラクタ Array
         * </summary>
         * <param name="elems">要素</param>
         */
        public Matrix(matelem_t[,] elems)
        {
            // ToDo: elems=nullは例外
            // ToDo: elems.GetLength(0)=0は例外
            // ToDo: elems.GetLength(1)=0は例外
            this.row = elems.GetLength(0);
            this.col = elems.GetLength(1);
            this.elems = elems;
        }

        /**
         * <summary>
         * インデクサ
         * </summary>
         * <param name="row">行</param>
         * <param name="col">列</param>
         */
        public matelem_t this[matidx_t row, matidx_t col]
        {
            set
            {
                // ToDo: row <= 0 || this.row - 1 < rowは例外
                // ToDo: col <= 0 || this.col - 1 < colは例外
                this.elems[row, col] = value;
            }

            get
            {
                // ToDo: row <= 0 || this.row - 1 < rowは例外
                // ToDo: col <= 0 || this.col - 1 < colは例外
                return this.elems[row, col];
            }
        }

        /**
         * <summary>
         * プロパティ Row
         * </summary>
         */
        public matidx_t Row
        {
            get
            {
                return this.row;
            }
        }

        /**
         * <summary>
         * プロパティ Col
         * </summary>
         */
        public matidx_t Col
        {
            get
            {
                return this.col;
            }
        }

        /**
         * <summary>
         * クローン
         * </summary>
         * <detail>行列のディープコピーを返す。</detail>
         */
        public virtual Matrix Clone()
        {
            matelem_t[,] new_array = new matelem_t[this.elems.GetLength(0), this.elems.GetLength(1)];
            Array.Copy(this.elems, new_array, new_array.Length);

            return new Matrix(new_array);
        }

        /**
         * <summary>
         * 要素のスワップ
         * </summary>
         * <param name="a_i">要素aのi行目</param>
         * <param name="a_j">要素aのj列名</param>
         * <param name="b_i">要素bのi行目</param>
         * <param name="b_j">要素bのj列目</param>
         */
        public void Swap(matidx_t a_i, matidx_t a_j, matidx_t b_i, matidx_t b_j)
        {
            // ToDo: row1 <= 0 || this.row - 1 < row1 は例外
            // ToDo: col1 <= 0 || this.col - 1 < col1 は例外
            // ToDo: row2 <= 0 || this.row - 1 < row2 は例外
            // ToDo: col2 <= 0 || this.col - 1 < col2 は例外
            matelem_t tmp;

            tmp = this[a_i, a_j];
            this[a_i, a_j] = this[b_i, b_j];
            this[b_i, b_j] = tmp;
        }

        /**
         * <summary>
         * 行列の足し算
         * </summary>
         * <param name="a">行列A</param>
         * <param name="b">行列B</param>
         */
        public static Matrix operator +(Matrix a, Matrix b)
        {
            // ToDo: a=nullは例外
            // ToDo: b=nullは例外
            // ToDo: a.Row != b.Row || a.Col != b.Colは例外
            Matrix result = new Matrix(a.Row, a.Col);

            for (matidx_t i = 0; i < result.Row; i++)
            {
                for (matidx_t j = 0; j < result.Col; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }

        /**
         * <summary>
         * 行列のスカラー倍
         * </summary>
         * <param name="sclr">スカラー値</param>
         * <param name="a">行列A</param>
         */
        public static Matrix operator *(double sclr, Matrix a)
        {
            // ToDo: a=nullは例外
            Matrix result = new Matrix(a.Row, a.Col);

            for (matidx_t i = 0; i < result.Row; i++)
            {
                for (matidx_t j = 0; j < result.Col; j++)
                {
                    result[i, j] = sclr * a[i, j];
                }
            }

            return result;
        }

        /**
         * <summary>
         * 行列の掛け算
         * </summary>
         * <param name="a">行列A</param>
         * <param name="b">行列B</param>
         */
        public static Matrix operator *(Matrix a, Matrix b)
        {
            // ToDo: a=nullは例外
            // ToDo: b=nullは例外
            // ToDo: a.Col != b.Rowは例外
            Matrix result = new Matrix(a.Row, b.Col);

            for (matidx_t i = 0; i < result.Row; i++)
            {
                for (matidx_t j = 0; j < result.Col; j++)
                {
                    result[i, j] = 0.0;

                    for (matidx_t k = 0; k < a.Col; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

    } // Class Matrix

} // namespace Matrices
