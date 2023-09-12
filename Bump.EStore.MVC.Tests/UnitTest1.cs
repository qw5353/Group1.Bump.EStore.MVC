using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bump.EStore.MVC.Tests
{
	/// <summary>
	/// UnitTest1 的摘要說明
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		public ProductRepository _repo;
		public UnitTest1()
		{
			
			_repo = new ProductRepository();
			
		}

		private TestContext testContextInstance;

		/// <summary>
		///取得或設定提供目前測試回合
		///相關資訊與功能的測試內容。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region 其他測試屬性
		//
		// 您可以使用下列其他屬性撰寫測試: 
		//
		// 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// 在執行每一項測試之後，使用 TestCleanup 執行程式碼
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestMethod1()
		{
			var data = _repo.GetProductEdits(5);

			Assert.IsNotNull(data);
		}
	}
}
