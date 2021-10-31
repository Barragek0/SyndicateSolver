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
        private bool _wasOpened;

        private bool betrayalWindowOpen;
        private bool syndicatePanelOpen;
        private bool syndicateTreeOpen;

        public override void Render()
        {
            Element betrayalWindow = GameController.Game.IngameState.IngameUi.BetrayalWindow;
            if (betrayalWindow.IsVisibleLocal != betrayalWindowOpen)
            {
                betrayalWindowOpen = !betrayalWindowOpen;
                LogMessage("BetrayalWindow is " + (betrayalWindowOpen ? "visible" : "not visible"));
                if (betrayalWindowOpen)
                {
                    IterateChildren(betrayalWindow, "BetrayalWindow");
                }
            }
            Element syndicatePanel = GameController.Game.IngameState.IngameUi.SyndicatePanel;
            if (syndicatePanel.IsVisibleLocal != syndicatePanelOpen)
            {
                syndicatePanelOpen = !syndicatePanelOpen;
                LogMessage("SyndicatePanel is " + (syndicatePanelOpen ? "visible" : "not visible"));
                if (syndicatePanelOpen)
                {
                    IterateChildren(syndicatePanel, "SyndicatePanel");
                }
            }
            Element syndicateTree = GameController.Game.IngameState.IngameUi.SyndicateTree;
            if (syndicateTree.IsVisibleLocal != syndicateTreeOpen)
            {
                syndicateTreeOpen = !syndicateTreeOpen;
                LogMessage("SyndicateTree is " + (syndicateTreeOpen ? "visible" : "not visible"));
                if (syndicateTreeOpen)
                {
                   // IterateChildren(syndicateTree, "SyndicateTree");
                }
            }
        }

        private void IterateChildren(Element element, String name)
        {
                for (var i = 0; i < element.ChildCount; i++)
                {
                    var child = element.GetChildAtIndex(i);
                    if (child != null)
                    {
                        if (child.Children.Count > 0)
                        {
                            for (var i1 = 0; i1 < child.ChildCount; i1++)
                            {
                                var childOfChild = element.GetChildAtIndex(i).GetChildAtIndex(i1);
                                if (childOfChild != null)
                                {
                                    LogMessage(name + " layer 2: " + (childOfChild.Text ?? "null"));
                                }
                            }
                        }
                            LogMessage(name + " layer 1: " + (child.Text ?? "null"));
                    }
                }
        }
    }
}