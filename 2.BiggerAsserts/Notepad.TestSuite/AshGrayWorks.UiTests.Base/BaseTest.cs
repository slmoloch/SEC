﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;
using TestStack.White;
using Approvals = ApprovalTests.Approvals;

namespace AshGrayWorks.UiTests.Base
{
    [TestFixture]
    public class BaseTest<TStartFlow>
        where TStartFlow : IFlow, new()
    {
        private Ignition ignition;

        protected TStartFlow Start
        {
            get
            {
                return ignition.Start<TStartFlow>();
            }
        }

        public void Verify()
        {
            ignition.Verify();
        }

        [TestFixtureSetUp]
        public void TestInitialize()
        {
            Approvals.RegisterDefaultNamerCreation(() => new ApprovalNamer());
        }

        [SetUp]
        public void SetUp()
        {
            ignition = new Ignition();
        }

        [TearDown]
        public void TearDown()
        {
            ignition.Dispose();
        }
    }
}
