using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MegaArtBotTests
{
    [TestClass]
    public class FunctionUnitTests
    {
        [TestMethod]
        public void TestRandom()
        {
            int m = 10;
            int tested = MegaArtBot.Functions.GetRandom(m);
            bool fact = tested <= m;
            Assert.AreEqual(fact,true);
        }

        [TestMethod]
        public async Task TestParse()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync("https://slivkisineta.ru/wp-content/uploads/2020/05/butterflies-25.jpg");
            IEnumerable<string> imgcol = MegaArtBot.Functions.ImgParser(document, ".jpg");
            Assert.IsNotNull(imgcol);
        }
    }
}
