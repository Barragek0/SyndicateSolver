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
            if (GameController.Game.IngameState.IngameUi.BetrayalWindow.IsVisibleLocal != betrayalWindowOpen)
            {
                betrayalWindowOpen = !betrayalWindowOpen;
                LogMessage("BetrayalWindow is " + (betrayalWindowOpen ? "visible" : "not visible"));
            }
            if (GameController.Game.IngameState.IngameUi.SyndicatePanel.IsVisibleLocal != syndicatePanelOpen)
            {
                syndicatePanelOpen = !syndicatePanelOpen;
                LogMessage("SyndicatePanel is " + (syndicatePanelOpen ? "visible" : "not visible"));
            }
            if (GameController.Game.IngameState.IngameUi.SyndicateTree.IsVisibleLocal != syndicateTreeOpen)
            {
                syndicateTreeOpen = !syndicateTreeOpen;
                LogMessage("SyndicateTree is " + (syndicateTreeOpen ? "visible" : "not visible"));
            }
            if (!_wasOpened)
            {
                try
                {
                    ParseMembers();
                } catch (Exception e)
                {
                    LogMessage("Error occured in parse members: " + e.Message);
                }
                _wasOpened = true;
            }
        }

        private void ParseMembers()
        {
                var betrayalWindow = GameController.Game.IngameState.IngameUi.BetrayalWindow;

                for (var i = 0; i < betrayalWindow.ChildCount; i++)
                {
                    var child = betrayalWindow.GetChildAtIndex(i);
                    if (child != null)
                    {
                        if (child.Children.Count > 0)
                        {
                            for (var i1 = 0; i1 < child.ChildCount; i1++)
                            {
                                var childOfChild = betrayalWindow.GetChildAtIndex(i).GetChildAtIndex(i1);
                                if (childOfChild != null)
                                {
                                    if (childOfChild.Text.Length > 0)
                                        LogMessage("BetrayalWindow child of child -> " + childOfChild.Text == null ? "null" : childOfChild.Text);
                                }
                            }
                        }
                        if (child.Text.Length > 0)
                            LogMessage("BetrayalWindow child -> " + child.Text);
                    }
                }

                var syndicatePanel = GameController.Game.IngameState.IngameUi.SyndicatePanel;

                for (var i = 0; i < syndicatePanel.ChildCount; i++)
                {
                    var child = syndicatePanel.GetChildAtIndex(i);
                    if (child != null)
                    {
                        if (child.Children.Count > 0)
                        {
                            for (var i1 = 0; i1 < child.ChildCount; i1++)
                            {
                                var childOfChild = syndicatePanel.GetChildAtIndex(i).GetChildAtIndex(i1);
                                if (childOfChild != null)
                                {
                                    if (childOfChild.Text.Length > 0)
                                        LogMessage("SyndicatePanel child of child -> " + childOfChild.Text == null ? "null" : childOfChild.Text);
                                }
                            }
                        }
                        if (child.Text.Length > 0)
                            LogMessage("SyndicatePanel child -> " + child.Text);
                    }
                }

               /* var syndicateTree = GameController.Game.IngameState.IngameUi.SyndicateTree;

                for (var i = 0; i < syndicateTree.ChildCount; i++)
                {
                    var child = syndicateTree.GetChildAtIndex(i);
                    if (child != null)
                    {
                        if (child.Children.Count > 0)
                        {
                            for (var i1 = 0; i1 < child.ChildCount; i1++)
                            {
                                var childOfChild = syndicateTree.GetChildAtIndex(i).GetChildAtIndex(i1);
                                if (childOfChild != null)
                                {
                                    if (childOfChild.Text.Length > 0)
                                        LogMessage("SyndicateTree child of child -> " + childOfChild.Text == null ? "null" : childOfChild.Text);
                                }
                            }
                        }
                        if (child.Text.Length > 0)
                            LogMessage("SyndicateTree child -> " + child.Text);
                    }
                }*/
        }
    }
}