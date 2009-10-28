using System.Collections;

using Microsoft.Office.Core;

namespace CC.OutlookGnuPG
{
    internal class PositionalCommandBar
    {
        private readonly CommandBar _bar;

        internal CommandBar Bar
        {
            get { return _bar; }
        }

        internal PositionalCommandBar(CommandBar bar)
        {
            _bar = bar;
        }

        internal void SavePosition(Properties.Settings settings)
        {
            settings.BarLeft = _bar.Left;
            settings.BarPosition = (int)_bar.Position;
            settings.BarPositionSaved = true;
            settings.BarRowIndex = _bar.RowIndex;
            settings.BarTop = _bar.Top;
            settings.Save();
        }

        internal void RestorePosition(IEnumerable bars, Properties.Settings settings)
        {
            // Position the bar
            if (settings.BarPositionSaved)
            {
                _bar.Position = (MsoBarPosition)settings.BarPosition;
                _bar.RowIndex = settings.BarRowIndex;
                _bar.Top = settings.BarTop;
                _bar.Left = settings.BarLeft;
            }
            else
            {
                CommandBar standardBar = null;
                foreach (CommandBar bar in bars)
                    if (bar.Name == "Standard")
                        standardBar = bar;

                if (standardBar != null)
                {
                    var oldPos = standardBar.Left;
                    _bar.RowIndex = standardBar.RowIndex;
                    _bar.Left = standardBar.Left + standardBar.Width;
                    _bar.Position = MsoBarPosition.msoBarTop;
                    standardBar.Left = oldPos;
                }
                else
                {
                    _bar.Position = MsoBarPosition.msoBarTop;
                }
            }
        }
    }
}