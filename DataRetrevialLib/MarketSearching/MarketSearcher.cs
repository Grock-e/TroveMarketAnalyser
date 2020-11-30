using MarketAnalyserLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace DataRetrevialLib
{
    public class MarketSearcher
    {
        private readonly Point SearchBar = new Point(687, 1044);

        private readonly Point ClearSearchBar = new Point(771, 1043);

        private readonly Point Search = new Point(577, 1235);

        private readonly Point NextPage = new Point(2116, 1310);

        private MouseController MController { get; set; } = new MouseController();

        private KeyboardController KController { get; set; } = new KeyboardController();

        public void EnterItem(KeyInputCode[] keyInputCodes)
        {
            MController.SetToPoint(SearchBar);
            MController.ClickLeftButton();

            foreach(KeyInputCode kIC in keyInputCodes)
            {
                KController.PressKey(kIC);
            }
            
        }

        public void ClearItem()
        {
            MController.SetToPoint(ClearSearchBar);
            MController.ClickLeftButton();
        }

        public void SearchItem()
        {
            MController.SetToPoint(Search);
            MController.ClickLeftButton();
        }

        public void GoToNextPage()
        {
            MController.SetToPoint(NextPage);
            MController.ClickLeftButton();
        }
    }
}
