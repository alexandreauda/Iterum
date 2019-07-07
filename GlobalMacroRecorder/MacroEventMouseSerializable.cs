using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalMacroRecorder
{
    /// <summary>
    /// Series of events that can be recorded any played back
    /// </summary>
    [Serializable]
    public class MacroEventMouseSerializable
    {

        public MacroEventType MacroEventType;
        public MouseEventArgsSerializable MouseEventArgs;
        public MouseButtons m_button;
        public int m_clicks;
        public int m_x;
        public int m_y;
        public int m_delta;
        public int TimeSinceLastEvent;

        public MacroEventMouseSerializable() { }

        public MacroEventMouseSerializable(MacroEventType macroEventType, MouseEventArgsSerializable eventArgs, int timeSinceLastEvent)
        {

            MacroEventType = macroEventType;
            MouseEventArgs = eventArgs;
            m_button = MouseEventArgs.getm_button();
            m_clicks = MouseEventArgs.getm_clicks();
            m_x = MouseEventArgs.getm_x();
            m_y = MouseEventArgs.getm_y();
            m_delta = MouseEventArgs.getm_delta();
            TimeSinceLastEvent = timeSinceLastEvent;

        }

    }
}
