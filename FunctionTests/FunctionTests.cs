using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functions;
using System;

namespace Functions.Tests
{
    /**
     * <summary>
     * Functionクラス 単体テスト
     * </summary>
     */
    [TestClass()]
    public class FunctionTests
    {
        /**
         * <summary>
         * コンストラクタ public Function()
         * </summary>
         */
        [TestMethod()]
        public void FunctionConstructorTest()
        {
            Function func = new TestFunc();
            PrivateObject prvt_obj_super = new PrivateObject(func, new PrivateType(typeof(Function)));
            PrivateType prvt_obj_sub = new PrivateType(typeof(TestFunc));

            // フィールドの取得
            int order = (int)prvt_obj_super.GetField("order");
            int unknown = (int)prvt_obj_super.GetField("unknown");
            int ORDER = (int)prvt_obj_sub.GetStaticField("ORDER");
            int UNKNOWN = (int)prvt_obj_sub.GetStaticField("UNKNOWN");

            // テスト
            Assert.AreEqual(ORDER, order);
            Assert.AreEqual(UNKNOWN, unknown);
        }

        /**
         * <summary>
         * プロパティ Order
         * </summary>
         */
        [TestMethod()]
        public void FunctionOrderTest()
        {
            Function func = new TestFunc();
            PrivateType prvt_obj = new PrivateType(typeof(TestFunc));

            // フィールドの取得
            int order = func.Order;
            int ORDER = (int)prvt_obj.GetStaticField("ORDER");

            // テスト
            Assert.AreEqual(ORDER, order);
        }

        /**
         * <summary>
         * プロパティ Unknown
         * </summary>
         */
        [TestMethod()]
        public void FunctionUnknownTest()
        {
            Function func = new TestFunc();
            PrivateType prvt_obj = new PrivateType(typeof(TestFunc));

            // フィールドの取得
            int unknown = func.Unknown;
            int UNKNOWN = (int)prvt_obj.GetStaticField("UNKNOWN");

            // テスト
            Assert.AreEqual(UNKNOWN, unknown);
        }

        /**
         * <summary>
         * 関数の実行
         * </summary>
         * <detail>メソッドExecuteが意図通りに使用できるインターフェースになっているかどうか確認する。</detail>
         */
        [TestMethod()]
        public void FunctionExecuteTest()
        {
            Function func = new TestFunc();

            // f(x, y) = x^2 + 3x + y^2 + 4
            // f(1, 2) = 1^2 + 3*1 + 2^2 + 4 = 12
            double expected = 12;
            double actual = func.Execute(1, 2);

            // テスト
            Assert.AreEqual(expected, actual);
        }

    } // class FunctionTests


    /**
     * <summary>
     * ２次関数 f(x, y) = x^2 + 3x + y^2 + 4
     * </summary>
     * <member name="ORDER">次数</member>
     * <member name="UNKNOWN">未知数の数</member>
     */
    class TestFunc : Function
    {
        private const int ORDER = 2;
        private const int UNKNOWN = 1;

        // コンストラクタ
        public TestFunc() : base(ORDER, UNKNOWN)
        { /* DO NOTHING */ }

        // 関数
        public override double Execute(params double[] x)
        {
            return (x[0] * x[0]) + (3.0 * x[0]) + (x[1] * x[1]) + 4.0;
        }

    } // class TestFunc

} // namespace Functions.Tests
