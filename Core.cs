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


        public override void Render()
        {
            var betrayalWindow = GameController.Game.IngameState.IngameUi.BetrayalWindow;

            if (betrayalWindow.IsVisibleLocal)
            {
                if (!_wasOpened)
                {
                    _wasOpened = true;
                    ParseMembers(betrayalWindow);
                    //    FindAndSolveCurrentInteraction(betrayalWindow);
                }

                // DrawSolvedData(betrayalWindow);
            }
            else
            {
                _wasOpened = false;
            }
        }

        private void ParseMembers(Element betrayalWindow)
        {
            for (var i = 0; i < betrayalWindow.ChildCount; i++)
            {
                var child = betrayalWindow.GetChildAtIndex(i);
                if (child.Children.Count > 0)
                {
                    for (var i1 = 0; i1 < child.ChildCount; i1++)
                    {
                        var childOfChild = betrayalWindow.GetChildAtIndex(i).GetChildAtIndex(i1);
                        LogMessage("Found child of child -> " + childOfChild.Text);
                    }
                }
                LogMessage("Found child -> " + child.Text);
            }
        }
    }
}