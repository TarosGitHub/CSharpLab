using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrices;
using System;

namespace Matrices.Tests
{
    /**
     * <summary>
     * Matrixクラス 単体テスト
     * </summary>
     */
    [TestClass()]
    public class MatrixTests
    {
        /**
         * <summary>
         * コンストラクタ public Matrix(matidx_t row, matidx_t col)
         * </summary>
         */
        [TestMethod()]
        public void MatrixConstructorRowColTest()
        {
            const int ROW = 3; // 行
            const int COL = 4; // 列
            Matrix matrix = new Matrix(ROW, COL);
            PrivateObject prvt_obj = new PrivateObject(matrix);

            // フィールドの取得
            int row = (int)prvt_obj.GetField("row");
            int col = (int)prvt_obj.GetField("col");
            double[,] elems = (double[,])prvt_obj.GetField("elems");

            // テスト
            Assert.AreEqual(ROW, row);
            Assert.AreEqual(COL, col);
            Assert.IsNotNull(elems);
            Assert.AreEqual(ROW, elems.GetLength(0));
            Assert.AreEqual(COL, elems.GetLength(1));
        }

        /**
         * <summary>
         * コンストラクタ public Matrix(double[,] elems)
         * </summary>
         */
        [TestMethod()]
        public void MatrixConstructorArrayTest()
        {
            const int ROW = 3; // 行
            const int COL = 4; // 列
            Matrix matrix = new Matrix(new double[,] {
                { 0.0, 0.1, 0.2, 0.3 }, 
                { 1.0, 1.1, 1.2, 1.3 }, 
                { 2.0, 2.1, 2.2, 2.3 }
            });
            PrivateObject prvt_obj = new PrivateObject(matrix);

            // フィールドの取得
            int row = (int)prvt_obj.GetField("row");
            int col = (int)prvt_obj.GetField("col");
            double[,] elems = (double[,])prvt_obj.GetField("elems");

            // テスト
            Assert.AreEqual(ROW, row);
            Assert.AreEqual(COL, col);
            Assert.IsNotNull(elems);
            Assert.AreEqual(ROW, elems.GetLength(0));
            Assert.AreEqual(COL, elems.GetLength(1));
        }

        /**
         * <summary>
         * インデクサ public matelem_t this[matidx_t row, matidx_t col]
         * </summary>
         */
        [TestMethod()]
        public void MatrixIndexerTest()
        {
            double[,] array = new double[,] {
                { 0.0, 0.1, 0.2, 0.3 },
                { 1.0, 1.1, 1.2, 1.3 },
                { 2.0, 2.1, 2.2, 2.3 }
            };
            Matrix matrix = new Matrix(array);

            // テスト
            Assert.AreEqual(array[0, 0], matrix[0, 0]);
            Assert.AreEqual(array[2, 3], matrix[2, 3]);
        }

        /**
         * <summary>
         * プロパティ public matidx_t Row
         * </summary>
         */
        [TestMethod()]
        public void MatrixRowTest()
        {
            const int ROW = 3; // 行
            const int COL = 4; // 列
            Matrix matrix = new Matrix(ROW, COL);

            // テスト
            Assert.AreEqual(ROW, matrix.Row);
        }

        /**
         * <summary>
         * プロパティ public matidx_t Col
         * </summary>
         */
        [TestMethod()]
        public void MatrixColTest()
        {
            const int ROW = 3; // 行
            const int COL = 4; // 列
            Matrix matrix = new Matrix(ROW, COL);

            // テスト
            Assert.AreEqual(COL, matrix.Col);
        }

        /**
         * <summary>
         * クローン public virtual Matrix Clone()
         * </summary>
         */
        [TestMethod()]
        public void MatrixCloneTest()
        {
            const int ROW = 3; // 行
            const int COL = 4; // 列
            Matrix matrix = new Matrix(ROW, COL);

            Matrix clone = matrix.Clone();

            PrivateObject matrix_prvt_obj = new PrivateObject(matrix);
            PrivateObject clone_prvt_obj = new PrivateObject(clone);
            double[,] matrix_elems = (double[,])matrix_prvt_obj.GetField("elems");
            double[,] clone_elems = (double[,])clone_prvt_obj.GetField("elems");

            // テスト
            Assert.AreNotEqual(matrix, clone);
            Assert.AreEqual(matrix.Row, clone.Row);
            Assert.AreEqual(matrix.Col, clone.Col);
            Assert.AreNotEqual(matrix_elems, clone_elems);
            Assert.AreEqual(matrix_elems.Length, clone_elems.Length);
        }

        /**
         * <summary>
         * 要素のスワップ
         * </summary>
         */
        [TestMethod()]
        public void MatrixSwapTest()
        {
            Matrix matrix = new Matrix(new double[,] {
                { 0.0, 0.1, 0.2, 0.3 },
                { 1.0, 1.1, 1.2, 1.3 },
                { 2.0, 2.1, 2.2, 2.3 }
            });

            double orig_0_0 = matrix[0, 0];
            double orig_2_3 = matrix[2, 3];
            matrix.Swap(0, 0, 2, 3);

            // テスト
            Assert.AreEqual(orig_0_0, matrix[2, 3]);
            Assert.AreEqual(orig_2_3, matrix[0, 0]);
        }

        /**
         * <summary>
         * 演算子オーバーロード public static Matrix operator +(Matrix a, Matrix b)
         * </summary>
         */
        [TestMethod()]
        public void MatrixOperatorPlusTest()
        {
            const double EPSR = 1.0e-10;
            Matrix mat_a = new Matrix(new double[,] {
                { 10.0, 10.1 },
                { 11.0, 11.1 }
            });
            Matrix mat_b = new Matrix(new double[,] {
                { 20.0, 20.1 },
                { 21.0, 21.1 }
            });
            Matrix expected = new Matrix(new double[,] {
                { 30.0, 30.2 },
                { 32.0, 32.2 }
            });
            Matrix actual;

            actual = mat_a + mat_b;

            // テスト
            Assert.AreEqual(expected[0, 0], actual[0, 0], EPSR);
            Assert.AreEqual(expected[0, 1], actual[0, 1], EPSR);
            Assert.AreEqual(expected[1, 0], actual[1, 0], EPSR);
            Assert.AreEqual(expected[1, 1], actual[1, 1], EPSR);
        }

        /**
         * <summary>
         * 演算子オーバーロード public static Matrix operator *(double sclr, Matrix a)
         * </summary>
         */
        [TestMethod()]
        public void MatrixOperatorSclrMultTest()
        {
            const double EPSR = 1.0e-10;
            const double sclr = 10.0;
            Matrix mat_a = new Matrix(new double[,] {
                { 10.0, 10.1 },
                { 11.0, 11.1 }
            });
            Matrix expected = new Matrix(new double[,] {
                { 100.0, 101.0 },
                { 110.0, 111.0 }
            });
            Matrix actual;

            actual = sclr * mat_a;

            // テスト
            Assert.AreEqual(expected[0, 0], actual[0, 0], EPSR);
            Assert.AreEqual(expected[0, 1], actual[0, 1], EPSR);
            Assert.AreEqual(expected[1, 0], actual[1, 0], EPSR);
            Assert.AreEqual(expected[1, 1], actual[1, 1], EPSR);
        }

        /**
         * <summary>
         * 演算子オーバーロード public static Matrix operator *(Matrix a, Matrix b)
         * </summary>
         */
        [TestMethod()]
        public void MatrixOperatorMultTest()
        {
            const double EPSR = 1.0e-10;
            Matrix mat_a = new Matrix(new double[,] {
                { 10.0,   10.0,  10.0 },
                { 100.0, 100.0, 100.0 }
            });
            Matrix mat_b = new Matrix(new double[,] {
                { 0.0, 1.0 },
                { 2.0, 3.0 },
                { 4.0, 5.0 }
            });
            Matrix expected = new Matrix(new double[,] {
                { 60.0,   90.0 },
                { 600.0, 900.0 }
            });
            Matrix actual;

            actual = mat_a * mat_b;

            // テスト
            Assert.AreEqual(expected[0, 0], actual[0, 0], EPSR);
            Assert.AreEqual(expected[0, 1], actual[0, 1], EPSR);
            Assert.AreEqual(expected[1, 0], actual[1, 0], EPSR);
            Assert.AreEqual(expected[1, 1], actual[1, 1], EPSR);
        }
    }
}
