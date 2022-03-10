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

        private static bool betrayalWindowOpen = false;
        private static bool syndicatePanelOpen = false;

        public override void Render()
        {
            Element betrayalWindow = GameController.Game.IngameState.IngameUi.BetrayalWindow;
            LogMessage("BetrayalWindow is " + (betrayalWindowOpen ? "visible" : "not visible"));
            if (betrayalWindow.IsVisibleLocal != betrayalWindowOpen)
            {
                betrayalWindowOpen = !betrayalWindowOpen;
                if (betrayalWindowOpen)
                {
                    IterateChildren(betrayalWindow);
                }
            }
            Element syndicatePanel = GameController.Game.IngameState.IngameUi.SyndicatePanel;
            LogMessage("SyndicatePanel is " + (syndicatePanelOpen ? "visible" : "not visible"));
            if (syndicatePanel.IsVisibleLocal != syndicatePanelOpen)
            {
                syndicatePanelOpen = !syndicatePanelOpen;
                if (syndicatePanelOpen)
                {
                    //IterateChildren(syndicatePanel, "SyndicatePanel");
                }
            }
        }

        private void IterateChildren(Element element)
        {
            Element aisling = element.GetElementByString("Aisling");
            if (aisling != null)
            {
                Graphics.DrawText("Aisling found below", new Vector2(aisling.GetClientRectCache.Center.X, aisling.GetClientRectCache.Center.Y-10), Color.White, FontAlign.Center);
                Graphics.DrawFrame(aisling.GetClientRectCache, Color.AliceBlue, 2);
            }
        }
    }
}