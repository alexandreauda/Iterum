﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalMacroRecorder
{

    /// <summary>
    /// All possible events that macro can record
    /// </summary>
    [Serializable]
    public enum MacroEventType
    {
        MouseMove,
        MouseDown,
        MouseUp,
        MouseWheel,
        KeyDown,
        KeyUp
    }

    /// <summary>
    /// Series of events that can be recorded any played back
    /// </summary>
    [Serializable]
    public class MacroEvent
    {

        public MacroEventType MacroEventType;
        public EventArgs EventArgs;
        public int TimeSinceLastEvent;

        public MacroEvent(){ }

        public MacroEvent(MacroEventType macroEventType, EventArgs eventArgs, int timeSinceLastEvent)
        {

            MacroEventType = macroEventType;
            EventArgs = eventArgs;
            TimeSinceLastEvent = timeSinceLastEvent;

        }

        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute TimeSinceLastEvent
        public int getTimeSinceLastEvent()
        {
            return TimeSinceLastEvent;
        }
        #endregion

        #region SETTER
        /****************** SETTER ******************/
        //Set the attribute TimeSinceLastEvent
        public void setTimeSinceLastEvent(int timeSinceLastEvent)
        {
            TimeSinceLastEvent = timeSinceLastEvent;//Set the attribute TimeSinceLastEvent
        }
        #endregion

    }

}
