using System;
using System.Collections.Generic;
using System.IO;
using ExileCore;
using ExileCore.PoEMemory;
using ExileCore.PoEMemory.Elements;
using ExileCore.Shared.Enums;
using SharpDX;

namespace SyndicateSolver
{
    public class Core : BaseSettingsPlugin<Settings>
    {//

        private bool betrayalWindowOpen;
        private bool syndicatePanelOpen;

        public override void Render()
        {
            Element betrayalWindow = GameController.Game.IngameState.IngameUi.BetrayalWindow;
            if (betrayalWindow.IsVisibleLocal != betrayalWindowOpen)
            {
                betrayalWindowOpen = !betrayalWindowOpen;
                LogMessage("BetrayalWindow is " + (betrayalWindowOpen ? "visible" : "not visible"));
                if (betrayalWindowOpen)
                {
                    IterateChildren(betrayalWindow);
                }
            }
            Element syndicatePanel = GameController.Game.IngameState.IngameUi.SyndicatePanel;
            if (syndicatePanel.IsVisibleLocal != syndicatePanelOpen)
            {
                syndicatePanelOpen = !syndicatePanelOpen;
                LogMessage("SyndicatePanel is " + (syndicatePanelOpen ? "visible" : "not visible"));
                if (syndicatePanelOpen)
                {
                    //IterateChildren(syndicatePanel, "SyndicatePanel");
                }
            }
        }

        private void IterateChildren(Element element)
        {
            element = element.GetChildAtIndex(1);
            for (int i = 0; i < element.Children.Count; i++)
            {
                if (i >= 10)
                {
                    Element syndicateMember = element.GetChildAtIndex(i).GetChildFromIndices(4, 1);
                    RectangleF boundingBox = syndicateMember.GetClientRectCache;
                    LogMessage("Found member: "+syndicateMember.Text);
                }
        }
    }
}