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
                var indexedChildren = 0;
                while (child.ChildCount > indexedChildren)
                {
                    var childOfChild = betrayalWindow.GetChildAtIndex(i).GetChildAtIndex(indexedChildren);
                    LogMessage("Found child of child -> " + childOfChild.Text);
                    indexedChildren++;
                }
                {

                }
                LogMessage("Found child -> "+child.Text);
            }
        }
    }
}