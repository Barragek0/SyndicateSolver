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
    {

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
            Element aisling = element.GetElementByString("Aisling");
            Graphics.DrawFrame(aisling.GetClientRectCache, Color.AliceBlue, 2);
        }
    }
}